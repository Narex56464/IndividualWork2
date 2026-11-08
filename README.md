app.patch(
  '/api/admin/appointments/:id/status',
  requireAdmin,
  async (req, res) => {
    const id = Number(req.params.id);
    const status = req.body?.status;

    const allowedStatuses = [
      'new',
      'confirmed',
      'cancelled'
    ];

    if (!Number.isSafeInteger(id) || id <= 0) {
      return res.status(400).json({
        error: 'Некорректный идентификатор записи.'
      });
    }

    if (!allowedStatuses.includes(status)) {
      return res.status(400).json({
        error: 'Недопустимый статус записи.'
      });
    }

    try {
      const [existing] = await pool.execute(
        'SELECT id FROM appointments WHERE id = ?',
        [id]
      );

      if (existing.length === 0) {
        return res.status(404).json({
          error: 'Запись не найдена.'
        });
      }

      await pool.execute(
        'UPDATE appointments SET status = ? WHERE id = ?',
        [status, id]
      );

      return res.json({
        success: true,
        status
      });
    } catch (error) {
      console.error(
        'Ошибка изменения статуса:',
        error.code,
        error.sqlMessage
      );

      return res.status(500).json({
        error: 'Не удалось сохранить статус записи.'
      });
    }
  }
);
