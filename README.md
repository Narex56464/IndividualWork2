ALTER TABLE appointments
ADD UNIQUE KEY uniq_specialist_slot (
  specialist_id,
  appt_date,
  appt_time
);;
