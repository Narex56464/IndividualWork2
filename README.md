/* Задание 6. Таблица расписания */

.schedule {
  width: 100%;
  border-collapse: collapse;

  background: var(--color-surface);
  font-size: 0.95rem;
}

/* Заголовки и обычные ячейки */
.schedule th,
.schedule td {
  padding: 12px 14px;
  border: 1px solid var(--color-border);

  text-align: left;
  vertical-align: middle;
}

/* Шапка таблицы */
.schedule thead {
  color: white;
  background: var(--color-primary);
}

.schedule th {
  font-weight: 700;
}

/* Чередование фона строк */
.schedule tbody tr:nth-child(even) {
  background: var(--color-bg);
}

/* Плавная смена фона */
.schedule tbody tr {
  transition: background-color 0.2s ease;
}

/* Подсветка строки при наведении */
.schedule tbody tr:hover {
  background: var(--color-border);
}

/* Число свободных мест */
.schedule th:last-child,
.schedule td:last-child {
  text-align: center;
}

.schedule td:last-child {
  color: var(--color-primary);
  font-weight: 700;
}

/* Подпись под таблицей */
.schedule__caption {
  caption-side: bottom;
  padding-top: 12px;

  color: var(--color-muted);
  font-size: 0.85rem;
  text-align: left;
}
