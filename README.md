/* Задание 7. Шаги поездки с CSS-счётчиком */

.steps {
  /* Создаём счётчик */
  counter-reset: step;

  /* Убираем стандартные номера и отступы */
  list-style: none;
  margin: 0;
  padding: 0;

  display: grid;
  gap: 18px;
}

.steps__item {
  /* Увеличиваем счётчик для каждого пункта */
  counter-increment: step;

  position: relative;
  min-height: 36px;
  padding-left: 50px;

  color: var(--color-text);
}

/* Номер в кружке перед текстом */
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
  backgr
