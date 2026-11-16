/* Задание 9. Вторая контрольная точка */

@media (max-width: 520px) {
  /* Уменьшаем общий отступ на всей странице */
  :root {
    --gap: 14px;
  }

  /* Шапка выстраивается в столбик */
  .header {
    flex-direction: column;
    align-items: flex-start;
  }

  /* Уменьшаем внутренние отступы первого экрана */
  .hero {
    padding: 44px 18px 26px;
  }

  /* Скрываем столбец «Гид» */
  .schedule th:nth-child(3),
  .schedule td:nth-child(3) {
    display: none;
  }

  /* Уменьшаем место слева от текста шагов */
  .steps__item {
    padding-left: 44px;
  }
}
