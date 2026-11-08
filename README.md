<!DOCTYPE html>
<html lang="ru">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Запись к специалисту</title>

  <style>
    body {
      margin: 0;
      padding: 30px 16px;
      background: #f3f5f9;
      color: #202938;
      font-family: Arial, sans-serif;
    }

    main {
      max-width: 560px;
      margin: auto;
      padding: 28px;
      background: white;
      border-radius: 18px;
    }

    h1 {
      margin-top: 0;
    }

    label {
      display: block;
      margin-top: 18px;
    }

    input, select, button {
      box-sizing: border-box;
      width: 100%;
      margin-top: 7px;
      padding: 12px;
      border: 1px solid #ccd3df;
      border-radius: 8px;
      font: inherit;
    }

    button {
      margin-top: 24px;
      background: #315ee8;
      color: white;
      border: none;
      cursor: pointer;
    }

    button:disabled {
      opacity: 0.6;
      cursor: wait;
    }

    #message {
      line-height: 1.5;
    }
  </style>
</head>

<body>
  <main>
    <h1>Запись к специалисту</h1>
    <p>Выберите специалиста и заполните данные.</p>

    <form id="booking-form">
      <label for="specialist">Специалист</label>
      <select id="specialist" name="specialist_id" required>
        <option value="">Загрузка специалистов...</option>
      </select>

      <label for="client-name">Ваше имя</label>
      <input
        id="client-name"
        name="client_name"
        type="text"
        minlength="2"
        maxlength="100"
        autocomplete="name"
        required
      >

      <label for="phone">Телефон</label>
      <input
        id="phone"
        name="client_phone"
        type="tel"
        minlength="5"
        maxlength="30"
        autocomplete="tel"
        required
      >

      <label for="date">Дата</label>
      <input
        id="date"
        name="appointment_date"
        type="date"
        required
      >

      <label for="time">Время по Москве</label>

<select id="time" name="appointment_time" required>
  <option value="">Выберите время</option>
  <option value="09:00">09:00–10:00</option>
  <option value="10:00">10:00–11:00</option>
  <option value="11:00">11:00–12:00</option>
  <option value="12:00">12:00–13:00</option>
  <option value="13:00">13:00–14:00</option>
  <option value="14:00">14:00–15:00</option>
  <option value="15:00">15:00–16:00</option>
  <option value="16:00">16:00–17:00</option>
  <option value="17:00">17:00–18:00</option>
  <option value="18:00">18:00–19:00</option>
  <option value="19:00">19:00–20:00</option>
</select>

<p>Приём: понедельник–пятница, с 09:00 до 20:00 по Москве.</p>

      <button id="submit-button" type="submit" disabled>
        Записаться
      </button>
    </form>

    <p id="message" role="status" aria-live="polite"></p>
  </main>

  <script>
    const form = document.getElementById('booking-form');
    const select = document.getElementById('specialist');
    const button = document.getElementById('submit-button');
    const message = document.getElementById('message');

    async function loadSpecialists() {
      try {
        const response = await fetch('/api/specialists');

        if (!response.ok) {
          throw new Error('Не удалось загрузить специалистов.');
        }

        const specialists = await response.json();

        select.replaceChildren(
          new Option('Выберите специалиста', '')
        );

        for (const specialist of specialists) {
          const text =
            specialist.name + ' — ' + specialist.profession;

          select.add(new Option(text, specialist.id));
        }

        if (specialists.length === 0) {
          message.textContent = 'Специалисты пока не добавлены.';
          return;
        }

        button.disabled = false;
      } catch (error) {
        select.replaceChildren(
          new Option('Список недоступен', '')
        );

        message.textContent =
          'Не удалось загрузить специалистов. Проверьте сервер.';
      }
    }

    form.addEventListener('submit', async (event) => {
      event.preventDefault();

      button.disabled = true;
      message.textContent = 'Сохраняем запись...';

      const data = Object.fromEntries(new FormData(form));

      try {
        const response = await fetch('/api/appointments', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify(data)
        });
        if (!response.headers.get('content-type')
          ?.includes('application/json')) {
          throw new Error(
            'Сервер вернул неожиданный ответ. ' +
            'Проверьте сохранение server.js и перезапустите сервер.'
          );
        }

        const result = await response.json();

        if (!response.ok) {
          throw new Error(
            result.error || 'Не удалось сохранить запись.'
          );
        }

        message.textContent =
          result.message + ' Номер записи: ' +
          result.appointment_id;

        form.reset();
      } catch (error) {
        message.textContent = error.message;
      } finally {
        button.disabled = false;
      }
    });
    const bookingDate = document.getElementById('date');
    const bookingTime = document.getElementById('time');

    const timeSlots = Array.from(bookingTime.options)
      .filter((option) => option.value)
      .map((option) => ({
        value: option.value,
        text: option.textContent
      }));

    let availabilityVersion = 0;

    async function updateAvailableTimes() {
  const version = ++availabilityVersion;

  bookingTime.replaceChildren(
    new Option('Выберите специалиста и дату', '')
  );
  bookingTime.disabled = true;

  if (!select.value || !bookingDate.value) {
    return;
  }

  const selectedDate = bookingDate.value;
  const selectedSpecialist = select.value;

  const weekday = new Date(
    selectedDate + 'T00:00:00Z'
  ).getUTCDay();

  if (weekday === 0 || weekday === 6) {
    bookingTime.replaceChildren(
      new Option('В выходные приёма нет', '')
    );
    return;
  }

  function getMoscowNow() {
    const parts = new Intl.DateTimeFormat('en-GB', {
      timeZone: 'Europe/Moscow',
      year: 'numeric',
      month: '2-digit',
      day: '2-digit',
      hour: '2-digit',
      minute: '2-digit',
      hourCycle: 'h23'
    }).formatToParts(new Date());

    const moscow = {};

    for (const part of parts) {
      moscow[part.type] = part.value;
    }

    return {
      date: moscow.year + '-' + moscow.month + '-' + moscow.day,
      time: moscow.hour + ':' + moscow.minute
    };
  }

  if (selectedDate < getMoscowNow().date) {
    bookingTime.replaceChildren(
      new Option('Выберите будущую дату', '')
    );
    return;
  }

  bookingTime.replaceChildren(
    new Option('Загрузка свободных часов...', '')
  );

  try {
    const params = new URLSearchParams({
      date: selectedDate,
      specialist_id: selectedSpecialist
    });

    const response = await fetch(
      '/api/availability?' + params.toString(),
      { cache: 'no-store' }
    );

    const data = await response.json();

    if (version !== availabilityVersion) {
      return;
    }

    if (!response.ok) {
      throw new Error(
        data.error || 'Не удалось загрузить расписание.'
      );
    }

    if (!Array.isArray(data.bookedTimes)) {
      throw new Error('Сервер вернул неожиданное расписание.');
    }

    const booked = new Set(data.bookedTimes);
    const now = getMoscowNow();

    bookingTime.replaceChildren(
      new Option('Выберите время', '')
    );

    for (const slot of timeSlots) {
      const isFuture =
        selectedDate > now.date ||
        (
          selectedDate === now.date &&
          slot.value > now.time
        );

      if (isFuture && !booked.has(slot.value)) {
        bookingTime.add(
          new Option(slot.text, slot.value)
        );
      }
    }

    if (bookingTime.options.length === 1) {
      bookingTime.replaceChildren(
        new Option('Свободных часов нет', '')
      );
      return;
    }

    bookingTime.disabled = false;
  } catch (error) {
    if (version !== availabilityVersion) {
      return;
    }

    bookingTime.replaceChildren(
      new Option('Не удалось загрузить часы', '')
    );

    message.textContent = error.message;
  }
}

    bookingDate.addEventListener(
      'change',
      updateAvailableTimes
    );

    select.addEventListener(
      'change',
      updateAvailableTimes
    );

    form.addEventListener('reset', () => {
      setTimeout(updateAvailableTimes, 0);
    });

    updateAvailableTimes();

    loadSpecialists();
  </script>
</body>
</html>
