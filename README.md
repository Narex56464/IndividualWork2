/* Задание 7. Нумерация шагов */

.steps {
  counter-reset: step;

  list-style: none;
  margin: 0;
  padding: 0;

  display: grid;
  gap: 18px;
}

.steps__item {
  counter-increment: step;

  position: relative;
  min-height: 34px;
  padding: 4px 0 4px 50px;
}

.steps__item::before {
  content: counter(step);

  position: absolute;
  top: 0;
  left: 0;

  display: grid;
  place-items: center;

  width: 34px;
  height: 34px;
  border-radius: 50%;

  color: white;
  background: var(--color-primary);

  font-size: 16px;
  font-weight: 700;
  line-height: 1;
}
