    <script>
    const tbody = document.getElementById('appointments');
    const message = document.getElementById('message');
    const refresh = document.getElementById('refresh');

    function formatDate(value) {
      const parts = String(value).slice(0, 10).split('-');

      if (parts.length !== 3) {
        return String(value);
      }

      return parts[2] + '.' + parts[1] + '.' + parts[0];
    }

    async function loadAppointments() {
      refresh.disabled = true;
      message.textContent = 'Загружаем записи...';
      tbody.replaceChildren();

      try {
        const response = await fetch('/api/admin/appointments', {
          credentials: 'same-origin',
          cache: 'no-store'
        });

        if (response.status === 401) {
          throw new Error(
            'Вход не выполнен. Обновите страницу и введите логин и пароль.'
          );
        }

        const result = await response.json();

        if (!response.ok) {
          throw new Error(
            result.error || 'Не удалось загрузить записи.'
          );
        }

        if (!Array.isArray(result)) {
          throw new Error('Сервер вернул неожиданный ответ.');
        }

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
    message.textContent = result.length === 0
      ? 'Записей пока нет.'
      : 'Всего записей: ' + result.length;
  } catch (error) {
    message.textContent =
      'Не удалось обновить список. ' + error.message;
  } finally {
    refresh.disabled = false;
  }
}

refresh.addEventListener('click', loadAppointments);
loadAppointments();
</script> 
</body>
</html>
