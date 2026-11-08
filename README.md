const statusCell = document.createElement('td');
const statusSelect = document.createElement('select');

statusSelect.setAttribute(
  'aria-label',
  'Статус записи №' + appointment.id
);

for (const [value, label] of Object.entries(statusLabels)) {
  const option = document.createElement('option');
  option.value = value;
  option.textContent = label;
  statusSelect.append(option);
}

statusSelect.value = appointment.status;

statusSelect.addEventListener('change', async () => {
  const previousStatus = appointment.status;
  const newStatus = statusSelect.value;

  statusSelect.disabled = true;

  try {
    const response = await fetch(
      '/api/admin/appointments/' + appointment.id + '/status',
      {
        method: 'PATCH',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify({
          status: newStatus
        })
      }
    );

    if (response.status === 401) {
      throw new Error(
        'Вход не выполнен. Обновите страницу и войдите снова.'
      );
    }

    const result = await response.json();

    if (!response.ok) {
      throw new Error(
        result.error || 'Не удалось сохранить статус.'
      );
    }

    appointment.status = newStatus;
  } catch (error) {
    statusSelect.value = previousStatus;

    alert(
      'Не удалось изменить статус. ' + error.message
    );
  } finally {
    statusSelect.disabled = false;
  }
});

statusCell.append(statusSelect);
row.append(statusCell);
