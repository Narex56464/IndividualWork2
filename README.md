<!DOCTYPE html>
<html lang="ru">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Админ-панель — записи</title>

  <style>
    body {
      margin: 0;
      padding: 30px 16px;
      background: #f3f5f9;
      color: #202938;
      font-family: Arial, sans-serif;
    }

    main {
      max-width: 1100px;
      margin: auto;
    }

    header {
      display: flex;
      align-items: center;
      justify-content: space-between;
      flex-wrap: wrap;
      gap: 16px;
      margin-bottom: 20px;
    }

    h1 {
      margin: 0;
    }

    button {
      padding: 12px 20px;
      border: none;
      border-radius: 8px;
      background: #315ee8;
      color: white;
      font: inherit;
      cursor: pointer;
    }

    button:disabled {
      opacity: 0.6;
      cursor: wait;
    }

    .table-wrapper {
      overflow-x: auto;
      background: white;
      border-radius: 12px;
    }

    table {
      width: 100%;
      border-collapse: collapse;
      min-width: 750px;
    }

    th, td {
      padding: 15px;
      text-align: left;
      border-bottom: 1px solid #e5e9f0;
    }

    th {
      background: #eaf0ff;
    }

    #message {
      line-height: 1.5;
    }

    a {
      color: #315ee8;
    }
  </style>
</head>

<body>
  <main>
    <header>
      <h1>Записи клиентов</h1>
      <button id="refresh" type="button">Обновить</button>
    </header>

    <p>
      <a href="/index.html">Открыть страницу записи</a>
    </p>

    <p id="message" role="status" aria-live="polite">
      Загружаем записи...
    </p>

    <div class="table-wrapper">
      <table>
        <thead>
          <tr>
            <th scope="col">Номер</th>
            <th scope="col">Клиент</th>
            <th scope="col">Телефон</th>
            <th scope="col">Специалист</th>
            <th scope="col">Дата</th>
            <th scope="col">Время</th>
          </tr>
        </thead>
        <tbody id="appointments"></tbody>
      </table>
    </div>
  </main>

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
