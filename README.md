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
     <div class="search-wrapper">
      <label for="appointment-search">
        Поиск по имени или телефону
      </label>

      <input
        id="appointment-search"
        type="search"
        placeholder="Введите имя или телефон"
        autocomplete="off"
      >
    </div>


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
            <th scope="col">Статус</th>
            <th scope="col">Действия</th> 
          </tr>
        </thead>
        <tbody id="appointments"></tbody>
      </table>
    </div>
  </main>
      <dialog id="edit-dialog" aria-labelledby="edit-title">
    <form id="edit-form">
      <h2 id="edit-title">Редактирование записи</h2>

      <input id="edit-id" type="hidden">

      <label for="edit-name">Имя клиента</label>
      <input
        id="edit-name"
        type="text"
        minlength="2"
        maxlength="100"
        required
      >

      <label for="edit-phone">Телефон</label>
      <input
        id="edit-phone"
        type="tel"
        minlength="5"
        maxlength="30"
        required
      >

      <label for="edit-specialist">Специалист</label>
      <select id="edit-specialist" required></select>

      <label for="edit-date">Дата</label>
      <input id="edit-date" type="date" required>

      <label for="edit-time">Время</label>
      <select id="edit-time" required>
        <option value="09:00">09:00</option>
        <option value="10:00">10:00</option>
        <option value="11:00">11:00</option>
        <option value="12:00">12:00</option>
        <option value="13:00">13:00</option>
        <option value="14:00">14:00</option>
        <option value="15:00">15:00</option>
        <option value="16:00">16:00</option>
        <option value="17:00">17:00</option>
        <option value="18:00">18:00</option>
        <option value="19:00">19:00</option>
      </select>

      <p id="edit-message" role="status" aria-live="polite"></p>

      <div class="edit-actions">
        <button id="edit-save" type="submit" disabled>
          Сохранить
        </button>

        <button id="edit-cancel" type="button">
          Отмена
        </button>
      </div>
    </form>
  </dialog>

  <input id="edit-id" type="hidden">

  <label for="edit-name">Имя клиента</label>
  <input
    id="edit-name"
    type="text"
    minlength="2"
    maxlength="100"
    required
  >

  <label for="edit-phone">Телефон</label>
  <input
    id="edit-phone"
    type="tel"
    minlength="5"
    maxlength="30"
    required
  >

  <label for="edit-specialist">Специалист</label>
  <select id="edit-specialist" required></select>

  <label for="edit-date">Дата</label>
  <input id="edit-date" type="date" required>

  <label for="edit-time">Время</label>
  <select id="edit-time" required>
    <option value="09:00">09:00</option>
    <option value="10:00">10:00</option>
    <option value="11:00">11:00</option>
    <option value="12:00">12:00</option>
    <option value="13:00">13:00</option>
    <option value="14:00">14:00</option>
    <option value="15:00">15:00</option>
    <option value="16:00">16:00</option>
    <option value="17:00">17:00</option>
    <option value="18:00">18:00</option>
    <option value="19:00">19:00</option>
  </select>

  <p id="edit-message" role="status" aria-live="polite"></p>

  <div class="edit-actions">
    <button id="edit-save" type="submit" disabled>
      Сохранить
    </button>

    <button id="edit-cancel" type="button">
      Отмена
    </button>
  </div>
</form>
  <script>
    const tbody = document.getElementById('appointments');
    const message = document.getElementById('message');
    const refresh = document.getElementById('refresh');
    const searchInput = document.getElementById('appointment-search');
    const editDialog = document.getElementById('edit-dialog');
const editForm = document.getElementById('edit-form');
const editId = document.getElementById('edit-id');
const editName = document.getElementById('edit-name');
const editPhone = document.getElementById('edit-phone');
const editSpecialist = document.getElementById('edit-specialist');
const editDate = document.getElementById('edit-date');
const editTime = document.getElementById('edit-time');
const editMessage = document.getElementById('edit-message');
const editSave = document.getElementById('edit-save');
const editCancel = document.getElementById('edit-cancel');

editCancel.addEventListener('click', () => {
  editDialog.close();
});

let editSaving = false;

editDialog.addEventListener('cancel', (event) => {
  if (editSaving) {
    event.preventDefault();
  }
});

editForm.addEventListener('submit', async (event) => {
  event.preventDefault();

  if (editSaving || editSave.disabled) {
    return;
  }

  if (!editForm.reportValidity()) {
    return;
  }

  const id = editId.value;

  const payload = {
    specialist_id: Number(editSpecialist.value),
    client_name: editName.value.trim(),
    client_phone: editPhone.value.trim(),
    appointment_date: editDate.value,
    appointment_time: editTime.value
  };

  editSaving = true;

  const controls = Array.from(
    editForm.querySelectorAll('input, select, button')
  );

  const previousDisabled = controls.map(
    (control) => control.disabled
  );

  for (const control of controls) {
    control.disabled = true;
  }

  editMessage.textContent = 'Сохраняем изменения...';

  try {
    const response = await fetch(
      '/api/admin/appointments/' + encodeURIComponent(id),
      {
        method: 'PATCH',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
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
        result.error || 'Не удалось сохранить изменения.'
      );
    }

    editDialog.close();
    await loadAppointments();
  } catch (error) {
    editMessage.textContent = error.message;
  } finally {
    controls.forEach((control, index) => {
      control.disabled = previousDisabled[index];
    });

    editSaving = false;
  }
});


async function openEditDialog(appointment) {
  editForm.reset();

  editId.value = appointment.id;
  editName.value = appointment.client_name || '';
  editPhone.value = appointment.phone || '';
  editDate.value = String(appointment.appt_date).slice(0, 10);
  editTime.value = String(appointment.appt_time).slice(0, 5);

  editSave.disabled = true;
  editMessage.textContent = 'Загружаем специалистов...';
  edФitSpecialist.replaceChildren();

  editDialog.showModal();

  try {
    const response = await fetch('/api/specialists', {
      credentials: 'same-origin',
      cache: 'no-store'
    });

    if (!response.ok) {
      throw new Error('Не удалось загрузить специалистов.');
    }

    const specialists = await response.json();

    if (!Array.isArray(specialists)) {
      throw new Error('Сервер вернул неожиданный ответ.');
    }

    for (const specialist of specialists) {
      const option = document.createElement('option');
      option.value = String(specialist.id);
      option.textContent = specialist.name;
      editSpecialist.append(option);
    }

    editSpecialist.value = String(appointment.specialist_id);

    if (!editSpecialist.value) {
      throw new Error(
        'Не удалось выбрать текущего специалиста. ' +
        'Проверьте, что API записей возвращает specialist_id.'
      );
    }

   editMessage.textContent = '';
editSave.disabled = false;

  } catch (error) {
    editMessage.textContent = error.message;
  }
}

let appointmentsLoaded = false;

function filterAppointments() {
  if (!appointmentsLoaded) {
    return;
  }

  const query = searchInput.value.trim().toLowerCase();
  const phoneQuery = query.replace(/\D/g, '');

  let visibleCount = 0;

  for (const row of tbody.rows) {
    const name = row.cells[1].textContent.toLowerCase();
    const phone = row.cells[2].textContent;
    const phoneDigits = phone.replace(/\D/g, '');

    const matches =
      query === '' ||
      name.includes(query) ||
      phone.toLowerCase().includes(query) ||
      (
        phoneQuery.length > 0 &&
        /^[\d\s()+.-]+$/.test(query) &&
        phoneDigits.includes(phoneQuery)
      );

    row.hidden = !matches;

    if (matches) {
      visibleCount++;
    }
  }

  const total = tbody.rows.length;

  if (total === 0) {
    message.textContent = 'Записей пока нет.';
  } else if (query === '') {
    message.textContent = 'Всего записей: ' + total;
  } else {
    message.textContent =
      'Найдено записей: ' + visibleCount + ' из ' + total;
  }
}

searchInput.addEventListener('input', filterAppointments);
const statusLabels = {
  new: 'Новая',
  confirmed: 'Подтверждена',
  cancelled: 'Отменена'
};


    function formatDate(value) {
      const parts = String(value).slice(0, 10).split('-');

      if (parts.length !== 3) {
        return String(value);
      }

      return parts[2] + '.' + parts[1] + '.' + parts[0];
    }

    async function loadAppointments() {
  appointmentsLoaded = false;
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

const actionCell = document.createElement('td');

const editButton = document.createElement('button');
editButton.type = 'button';
editButton.textContent = 'Редактировать';
editButton.style.marginRight = '8px';

editButton.addEventListener('click', () => {
  openEditDialog(appointment);
});

actionCell.append(editButton);


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
   appointmentsLoaded = true;
filterAppointments();
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
