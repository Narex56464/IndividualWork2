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

      bookingTime.replaceChildren(
        new Option('Загрузка свободных часов...', '')
      );

      try {
        const params = new URLSearchParams({
          date: bookingDate.value,
          specialist_id: select.value
        });

        const response = await fetch(
          '/api/availability?' + params.toString()
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

        const booked = new Set(data.bookedTimes);

        bookingTime.replaceChildren(
          new Option('Выберите время', '')
        );

        for (const slot of timeSlots) {
          if (!booked.has(slot.value)) {
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
