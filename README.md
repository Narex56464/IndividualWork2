app.delete('/api/admin/appointments/:id', requireAdmin, async (req, res) => {
  try {
    const id = Number(req.params.id);

    if (!Number.isInteger(id) || id <= 0) {
      return res.status(400).json({
        error: 'Некорректный идентификатор записи.'
      });
    }

    const [result] = await pool.query(
      'DELETE FROM appointments WHERE id = ?',
      [id]
    );

    if (result.affectedRows === 0) {
      return res.status(404).json({
        error: 'Запись не найдена.'
      });
    }

    res.json({
      success: true
    });
  } catch (error) {
    console.error(
      'Ошибка удаления записи:',
      error.code,
      error.sqlMessage
    );

    res.status(500).json({
      error: 'Не удалось удалить запись.'
    });
  }
});
