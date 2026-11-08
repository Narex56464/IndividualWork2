const [rows] = await pool.query(
  'SELECT a.id, a.specialist_id, s.name AS specialist_name, ' +
  'a.client_name, a.phone, a.appt_date, a.appt_time, ' +
  'a.created_at, a.status ' +
  'FROM appointments AS a ' +
  'JOIN specialists AS s ON s.id = a.specialist_id ' +
  'ORDER BY a.appt_date DESC, a.appt_time DESC, a.id DESC'
);
