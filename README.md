      console.log('Маршрут удаления подключён. Файл:', __filename);

app.delete('/api/admin/appointments/:id', requireAdmin, async (req, res) => {
