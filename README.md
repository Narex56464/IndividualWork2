ALTER TABLE appointments
ADD COLUMN status VARCHAR(20) NOT NULL DEFAULT 'new'
AFTER appt_time;
