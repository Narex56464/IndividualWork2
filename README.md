const todaySummary = document.getElementById('today-summary');

function updateTodaySummary() {
  const today = getMoscowDate();
  let count = 0;

  for (const row of tbody.rows) {
    const statusSelect = row.cells[6].querySelector('select');

    if (
      row.dataset.date === today &&
      statusSelect &&
      statusSelect.value !== 'cancelled'
    ) {
      count++;
    }
  }

  todaySummary.textContent =
    'Записей на сегодня (без отменённых): ' + count;
}
