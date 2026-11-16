/* Задание 8. Боковая панель */

.sidebar {
  padding: 20px;

  border: 1px solid var(--color-border);
  border-radius: var(--radius);

  background: var(--color-surface);
  box-shadow: var(--shadow);
}

.sidebar__title {
  margin-bottom: 14px;

  font-size: 1.25rem;
  line-height: 1.3;
}

.facts {
  display: grid;
  gap: 10px;

  margin: 0;
  padding-left: 20px;
}

.facts li::marker {
  color: var(--color-accent);
}

.sidebar__note {
  margin-top: 16px;
  padding-top: 14px;

  border-top: 1px solid var(--color-border);

  color: var(--color-muted);
  font-size: 0.9rem;
}


/* Форма бронирования */

.booking {
  padding: 24px;

  border: 1px solid var(--color-border);
  border-radius: var(--radius);

  background: var(--color-surface);
  box-shadow: var(--shadow);
}

.form {
  display: grid;
  grid-template-columns: minmax(0, 1fr);
  gap: 18px;
}

/* Подпись и поле располагаются друг под другом */
.form__field {
  display: flex;
  flex-direction: column;
  gap: 6px;

  min-width: 0;
}

.form__label {
  font-weight: 700;
}

/* Общий вид полей */
.form__input {
  width: 100%;
  min-width: 0;

  padding: 11px 12px;

  border: 1px solid var(--color-border);
  border-radius: var(--radius);

  font: inherit;
  color: var(--color-text);
  background: var(--color-surface);

  transition:
    border-color 0.2s ease,
    outline-color 0.2s ease;
}

.form__input::placeholder {
  color: var(--color-muted);
}

.form__input:focus {
  border-color: var(--color-primary);
}

.form__input:focus-visible {
  outline: 2px solid var(--color-primary);
  outline-offset: 2px;
}

/* Поле пожеланий можно растянуть по высоте */
textarea.form__input {
  min-height: 110px;
  resize: vertical;
}

/* Эти элементы занимают всю ширину сетки */
.form__field--wide {
  grid-column: 1 / -1;
}

/* Чекбокс и текст согласия */
.checkbox {
  display: flex;
  align-items: flex-start;
  gap: 10px;

  cursor: pointer;
}

.checkbox input {
  flex-shrink: 0;

  width: 18px;
  height: 18px;
  margin-top: 4px;

  accent-color: var(--color-primary);
}

/* Кнопка отправки */
.form__submit {
  grid-column: 1 / -1;
  justify-self: start;
}

/* На более широком экране — два столбца полей */
/* 600px — выбранный для этого варианта порог */
@media (min-width: 600px) {
  .form {
    grid-template-columns: repeat(2, minmax(0, 1fr));
  }
}
