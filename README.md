app.patch(
  '/api/admin/appointments/:id',
  requireAdmin,
  async (req, res) => {
    const id = Number(req.params.id);
    const body = req.body || {};

    const specialistId = Number(body.specialist_id);

    const name = typeof body.client_name === 'string'
      ? body.client_name.trim()
      : '';

    const phone = typeof body.client_phone === 'string'
      ? body.client_phone.trim()
      : '';

    const date = typeof body.appointment_date === 'string'
      ? body.appointment_date
      : '';

    const time = typeof body.appointment_time === 'string'
      ? body.appointment_time
      : '';

    if (!Number.isSafeInteger(id) || id <= 0) {
      return res.status(400).json({
        error: 'Некорректный идентификатор записи.'
      });
    }

    if (
      !Number.isSafeInteger(specialistId) ||
      specialistId <= 0 ||
      name.length < 2 ||
      name.length > 100 ||
      phone.length < 5 ||
      phone.length > 30
    ) {
      return res.status(400).json({
        error: 'Выберите специалиста, укажите имя и телефон.'
      });
    }

    const parsedDate = new Date(date + 'T00:00:00Z');

    const validDate =
      /^\d{4}-\d{2}-\d{2}$/.test(date) &&
      Number.isFinite(parsedDate.getTime()) &&
      parsedDate.toISOString().slice(0, 10) === date &&
      Number(date.slice(0, 4)) >= 1000;

    const validTime = /^(09|1[0-9]):00$/.test(time);

    if (!validDate || !validTime) {
      return res.status(400).json({
        error:
          'Укажите корректную дату и время с 09:00 до 19:00, ' +
          'ровно в начале часа.'
      });
    }

    const timeWithSeconds = time + ':00';
    let connection;

    try {
      connection = await pool.getConnection();
      await connection.beginTransaction();

      const [rows] = await connection.execute(
        'SELECT specialist_id, appt_date, appt_time ' +
        'FROM appointments WHERE id = ? FOR UPDATE',
        [id]
      );

      if (rows.length === 0) {
        await connection.rollback();

        return res.status(404).json({
          error: 'Запись не найдена.'
        });
      }

      const current = rows[0];

      const scheduleChanged =
        Number(current.specialist_id) !== specialistId ||
        String(current.appt_date).slice(0, 10) !== date ||
        String(current.appt_time).slice(0, 5) !== time;

      if (scheduleChanged) {
        const weekday = parsedDate.getUTCDay();

        if (weekday === 0 || weekday === 6) {
          await connection.rollback();

          return res.status(400).json({
            error: 'Приём только с понедельника по пятницу.'
          });
        }

        const parts = new Intl.DateTimeFormat('en-GB', {
          timeZone: 'Europe/Moscow',
          year: 'numeric',
          month: '2-digit',
          day: '2-digit',
          hour: '2-digit',
          minute: '2-digit',
          hourCycle: 'h23'
        }).formatToParts(new Date());

        const moscow = {};

        for (const part of parts) {
          moscow[part.type] = part.value;
        }

        const today =
          moscow.year + '-' + moscow.month + '-' + moscow.day;

        const currentTime = moscow.hour + ':' + moscow.minute;

        if (
          date < today ||
          (date === today && time <= currentTime)
        ) {
          await connection.rollback();

          return res.status(400).json({
            error:
              'Нельзя перенести запись на прошедшее время. ' +
              'Выберите будущую дату и время по Москве.'
          });
        }
      }

      await connection.execute(
        'UPDATE appointments ' +
        'SET specialist_id = ?, client_name = ?, phone = ?, ' +
        'appt_date = ?, appt_time = ? ' +
        'WHERE id = ?',
        [specialistId, name, phone, date, timeWithSeconds, id]
      );

      await connection.commit();

      return res.json({
        success: true
      });
    } catch (error) {
      if (connection) {
        try {
          await connection.rollback();
        } catch (rollbackError) {
          console.error(
            'Ошибка отката редактирования:',
            rollbackError.code
          );
        }
      }

      if (error.code === 'ER_DUP_ENTRY') {
        return res.status(409).json({
          error: 'Это время уже занято. Выберите другое.'
        });
      }

      if (error.code === 'ER_NO_REFERENCED_ROW_2') {
        return res.status(400).json({
          error: 'Выбранный специалист не найден.'
        });
      }

      console.error(
        'Ошибка редактирования записи:',
        error.code,
        error.sqlMessage
      );

      return res.status(500).json({
        error: 'Не удалось сохранить изменения.'
      });
    } finally {
      if (connection) {
        connection.release();
      }
    }
  }
);
