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
