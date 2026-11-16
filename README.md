/* Дополнительная адаптация для узкого экрана */

@media (max-width: 600px) {
  /* Компактные отступы */
  .hero {
    padding: 50px 20px 30px;
  }

  .booking,
  .footer {
    padding: 18px;
  }

  /* Меню переносится под логотип */
  .nav {
    width: 100%;
  }

  .nav__list {
    gap: 8px 14px;
  }

  .nav__link {
    font-size: 0.9rem;
  }

  /* Карточки занимают одну колонку */
  .tours {
    grid-template-columns: minmax(0, 1fr);
  }

  /* Кнопка формы на всю ширину */
  .form__submit {
    justify-self: stretch;
    width: 100%;
  }

  /* Длинный текст в таблице может переноситься */
  .schedule {
    table-layout: fixed;
    font-size: 0.8rem;
  }

  .schedule th,
  .schedule td {
    padding: 8px 5px;
    overflow-wrap: anywhere;
  }

  /* На телефоне скрываем столбец «Гид» */
  .schedule th:nth-child(3),
  .schedule td:nth-child(3) {
    display: none;
  }
}
