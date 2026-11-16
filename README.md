/* Задание 4. Первый экран */

.hero {
  position: relative;
  overflow: hidden;

  padding: 60px 30px;
  border-radius: var(--radius);

  color: white;
  background: linear-gradient(120deg, #2f4b8f, #7b2ff7);

  animation: hero-appear 0.7s ease both;
}

/* Заголовок */
.hero__title {
  max-width: 18ch;
  margin-bottom: 16px;

  font-size: clamp(1.8rem, 4vw, 3rem);
  line-height: 1.15;
}

/* Описание */
.hero__text {
  max-width: 52ch;
  margin-bottom: 24px;
}

/* Возрастная метка */
.hero__badge {
  position: absolute;
  top: 16px;
  right: 16px;

  padding: 4px 12px;
  border-radius: 999px;

  color: var(--color-text);
  background: var(--color-surface);

  font-weight: 700;
}

/* Общий стиль кнопок */
.button {
  display: inline-block;

  padding: 12px 22px;
  border: none;
  border-radius: 999px;

  font: inherit;
  font-weight: 700;
  line-height: 1.3;
  text-align: center;
  text-decoration: none;

  color: white;
  background: var(--color-accent);
  cursor: pointer;

  transition:
    transform 0.25s ease,
    box-shadow 0.25s ease;
}

.button:hover {
  transform: translateY(-2px);
  box-shadow: var(--shadow);
}

/* Видимый фокус при управлении клавиатурой */
a:focus-visible,
button:focus-visible,
input:focus-visible,
select:focus-visible,
textarea:focus-visible {
  outline: 3px solid var(--color-accent);
  outline-offset: 4px;
}

/* Контрастный фокус кнопки на цветном фоне */
.hero .button:focus-visible {
  outline-color: var(--color-surface);
}

/* Появление первого экрана */
@keyframes hero-appear {
  from {
    opacity: 0;
    transform: translateY(16px);
  }

  to {
    opacity: 1;
    transform: translateY(0);
  }
}
