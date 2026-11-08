const dateFilter = document.getElementById('date-filter');
const filterDate = document.getElementById('filter-date');

function getMoscowDate(offsetDays = 0) {
  const parts = new Intl.DateTimeFormat('en-GB', {
    timeZone: 'Europe/Moscow',
    year: 'numeric',
    month: '2-digit',
    day: '2-digit'
  }).formatToParts(new Date());

  const values = {};

  for (const part of parts) {
    values[part.type] = part.value;
  }

  const date = new Date(
    values.year + '-' + values.month + '-' + values.day +
    'T00:00:00Z'
  );

  date.setUTCDate(date.getUTCDate() + offsetDays);

  return date.toISOString().slice(0, 10);
}

dateFilter.addEventListener('change', () => {
  filterDate.disabled = dateFilter.value !== 'custom';

  if (dateFilter.value === 'custom' && !filterDate.value) {
    filterDate.value = getMoscowDate();
  }

  filterAppointments();
});

filterDate.addEventListener('input', filterAppointments);
