for (const appointment of result) {
  const row = document.createElement('tr');

  const values = [
    appointment.id,
    appointment.client_name,
    appointment.phone,
    appointment.specialist_name,
    formatDate(appointment.appt_date),
    String(appointment.appt_time).slice(0, 5)
  ];

  for (const value of values) {
    const cell = document.createElement('td');
    cell.textContent = value == null ? '' : String(value);
    row.append(cell);
  }

  const actionCell = document.createElement('td');

  const deleteButton = document.createElement('button');
  deleteButton.type = 'button';
  deleteButton.textContent = 'Удалить';

  deleteButton.addEventListener('click', async () => {
    const confirmed = confirm(
      'Удалить запись №' + appointment.id + '?'
    );

    if (!confirmed) {
      return;
    }

    deleteButton.disabled = true;

    try {
      const response = await fetch(
        '/api/admin/appointments/' + appointment.id,
        {
          method: 'DELETE',
          credentials: 'same-origin'
        }
      );

      const result = await response.json();

      if (!response.ok) {
        throw new Error(
          result.error || 'Не удалось удалить запись.'
        );
      }

      await loadAppointments();
    } catch (error) {
      alert(
        'Не удалось удалить запись. ' + error.message
      );
    } finally {
      deleteButton.disabled = false;
    }
  });

  actionCell.append(deleteButton);
  row.append(actionCell);

  tbody.append(row);
}
