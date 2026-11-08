const exportCsv = document.getElementById('export-csv');

function escapeCsvCell(value) {
  let text = String(value ?? '')
    .replace(/[\r\n\t]+/g, ' ');

  if (/^\s*[=+\-@＝＋－＠]/u.test(text)) {
    text = '\t' + text;
  }

  return '"' + text.replace(/"/g, '""') + '"';
}

exportCsv.addEventListener('click', () => {
  if (!appointmentsLoaded) {
    alert('Сначала дождитесь загрузки записей.');
    return;
  }

  filterAppointments();

  const visibleRows = Array.from(tbody.rows).filter(
    (row) => !row.hidden
  );

  if (visibleRows.length === 0) {
    alert('Нет записей для выгрузки. Проверьте фильтры.');
    return;
  }

  const data = [
    [
      'Номер',
      'Клиент',
      'Телефон',
      'Специалист',
      'Дата',
      'Время',
      'Статус'
    ]
  ];

  for (const row of visibleRows) {
    const statusSelect = row.cells[6].querySelector('select');

    const statusText = statusSelect
      ? statusSelect.selectedOptions[0]?.textContent || ''
      : row.cells[6].textContent;

    data.push([
      row.cells[0].textContent,
      row.cells[1].textContent,
      row.cells[2].textContent,
      row.cells[3].textContent,
      row.cells[4].textContent,
      row.cells[5].textContent,
      statusText
    ]);
  }

  const csv = '\uFEFF' + data
    .map((values) => values.map(escapeCsvCell).join(';'))
    .join('\r\n');

  const blob = new Blob([csv], {
    type: 'text/csv;charset=utf-8;'
  });

  const url = URL.createObjectURL(blob);
  const link = document.createElement('a');

  link.href = url;
  link.download = 'appointments-' + getMoscowDate() + '.csv';

  document.body.append(link);
  link.click();
  link.remove();

  setTimeout(() => {
    URL.revokeObjectURL(url);
  }, 1000);
});
