/* Задание 2. Сетка страницы */

.page {
  display: grid;

  /* На узком экране — одна колонка */
  grid-template-columns: minmax(0, 1fr);
  grid-template-areas:
    "header"
    "hero"
    "content"
    "sidebar"
    "booking"
    "footer";

  gap: var(--gap);

  /* Ограничение ширины и выравнивание по центру */
  max-width: 1100px;
  margin: 0 auto;

  /* Боковые поля страницы */
  padding: 0 var(--gap);
}

/* Каждый блок занимает свою область */
.header {
  grid-area: header;
}

.hero {
  grid-area: hero;
  min-width: 0;
}

.content {
  grid-area: content;
  min-width: 0;
}

.sidebar {
  grid-area: sidebar;
  min-width: 0;
  align-self: start;
}

.booking {
  grid-area: booking;
  min-width: 0;
}

.footer {
  grid-area: footer;
  min-width: 0;
}

/* Начиная с 860px — две колонки */
@media (min-width: 860px) {
  .page {
    grid-template-columns: minmax(0, 1fr) 260px;

    grid-template-areas:
      "header  header"
      "hero    sidebar"
      "content sidebar"
      "booking booking"
      "footer  footer";
  }
}
