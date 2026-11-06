app.get('/api/admin/appointments', requireAdmin, async (req, res) => {
  try {
    const [rows] = await pool.query(
      'SELECT a.id, s.name AS specialist_name, ' +
      'a.client_name, a.phone, a.appt_date, a.appt_time, ' +
      'a.created_at ' +
      'FROM appointments AS a ' +
      'JOIN specialists AS s ON s.id = a.specialist_id ' +
      'ORDER BY a.appt_date DESC, a.appt_time DESC, a.id DESC'
    );

    res.json(rows);
  } catch (error) {
    console.error(
      'Ошибка просмотра записей:',
      error.code,
      error.sqlMessage
    );

    res.status(500).json({
      error: 'Не удалось загрузить записи.'
    });
  }
});
