const values = [
  appointment.id,
  appointment.client_name,
  appointment.phone,
  appointment.specialist_name,
  formatDate(appointment.appt_date),
  String(appointment.appt_time).slice(0, 5),
  statusLabels[appointment.status] || 'Неизвестный статус'
];
