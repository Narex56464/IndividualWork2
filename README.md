function filterAppointments() {
  if (!appointmentsLoaded) {
    return;
  }

  const query = searchInput.value.trim().toLowerCase();
  const phoneQuery = query.replace(/\D/g, '');
  const mode = dateFilter.value;

  let selectedDate = '';

  if (mode === 'today') {
    selectedDate = getMoscowDate();
  } else if (mode === 'tomorrow') {
    selectedDate = getMoscowDate(1);
  } else if (mode === 'custom') {
    selectedDate = filterDate.value;
  }

  let visibleCount = 0;

  for (const row of tbody.rows) {
    const name = row.cells[1].textContent.toLowerCase();
    const phone = row.cells[2].textContent;
    const phoneDigits = phone.replace(/\D/g, '');

    const matchesSearch =
      query === '' ||
      name.includes(query) ||
      phone.toLowerCase().includes(query) ||
      (
        phoneQuery.length > 0 &&
        /^[\d\s()+.-]+$/.test(query) &&
        phoneDigits.includes(phoneQuery)
      );

    const matchesDate =
      mode === 'all' ||
      (
        selectedDate !== '' &&
        row.dataset.date === selectedDate
      );

    const matches = matchesSearch && matchesDate;

    row.hidden = !matches;

    if (matches) {
      visibleCount++;
    }
  }

  const total = tbody.rows.length;

  if (total === 0) {
    message.textContent = 'Записей пока нет.';
  } else if (mode === 'custom' && !selectedDate) {
    message.textContent = 'Выберите дату для фильтра.';
  } else if (query === '' && mode === 'all') {
    message.textContent = 'Всего записей: ' + total;
  } else {
    message.textContent =
      'Найдено записей: ' + visibleCount + ' из ' + total;
  }
}
