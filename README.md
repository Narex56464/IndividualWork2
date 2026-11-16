<!DOCTYPE html>
<html lang="ru">
<head>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Экскурсионное бюро «Компас» — туры выходного дня</title>
  <link rel="stylesheet" href="css/style.css">
</head>
<body>

  <div class="page">

    <header class="header">
      <a class="logo" href="#">Компас<span class="logo__mark">.</span></a>
      <nav class="nav">
        <ul class="nav__list">
          <li><a class="nav__link" href="#tours">Туры</a></li>
          <li><a class="nav__link" href="#schedule">Расписание</a></li>
          <li><a class="nav__link" href="#how">Как проходит</a></li>
          <li><a class="nav__link" href="#booking">Бронирование</a></li>
        </ul>
      </nav>
    </header>

    <section class="hero">
      <span class="hero__badge">6+</span>
      <h1 class="hero__title">Туры выходного дня по России</h1>
      <p class="hero__text">Собираем небольшие группы до 16 человек, возим на комфортабельных автобусах и рассказываем то, чего нет в путеводителях.</p>
      <a class="button" href="#booking">Забронировать место</a>
    </section>

    <main class="content">
      <h2 class="section-title" id="tours">Популярные направления</h2>

      <div class="tours">
        <article class="tour">
          <img class="tour__photo" src="images/tour-altai.jpg" alt="Горные вершины Алтая" width="400" height="300">
          <div class="tour__body">
            <span class="tour__tag">Хит сезона</span>
            <h3 class="tour__title">Горный Алтай</h3>
            <p class="tour__text">Телецкое озеро, перевал Чике-Таман и ночёвка на турбазе у реки Катунь.</p>
            <p class="tour__meta"><span>5 дней</span><span class="tour__price">18 900 ₽</span></p>
          </div>
        </article>

        <article class="tour">
          <img class="tour__photo" src="images/tour-baikal.jpg" alt="Берег Байкала" width="400" height="300">
          <div class="tour__body">
            <h3 class="tour__title">Байкал зимой</h3>
            <p class="tour__text">Прозрачный лёд, остров Ольхон, прогулка на хивусе и баня на берегу.</p>
            <p class="tour__meta"><span>6 дней</span><span class="tour__price">32 500 ₽</span></p>
          </div>
        </article>

        <article class="tour">
          <img class="tour__photo" src="images/tour-kazan.jpg" alt="Вечерняя панорама Казани" width="400" height="300">
          <div class="tour__body">
            <span class="tour__tag">Для школьников</span>
            <h3 class="tour__title">Казань за два дня</h3>
            <p class="tour__text">Кремль, улица Баумана, Храм всех религий и мастер-класс по чак-чаку.</p>
            <p class="tour__meta"><span>2 дня</span><span class="tour__price">7 400 ₽</span></p>
          </div>
        </article>

        <article class="tour">
          <img class="tour__photo" src="images/tour-karelia.jpg" alt="Лес и озёра Карелии" width="400" height="300">
          <div class="tour__body">
            <h3 class="tour__title">Карелия: Кивач и Рускеала</h3>
            <p class="tour__text">Водопад Кивач, мраморный каньон, прогулка на лодке и карельская кухня.</p>
            <p class="tour__meta"><span>3 дня</span><span class="tour__price">14 200 ₽</span></p>
          </div>
        </article>
      </div>

      <h2 class="section-title" id="schedule">Расписание выездов</h2>

      <table class="schedule">
        <caption class="schedule__caption">Выезд от офиса на улице Ленинградской, 1. Сбор группы за 30 минут до отправления</caption>
        <thead>
          <tr>
            <th>Дата выезда</th>
            <th>Направление</th>
            <th>Гид</th>
            <th>Мест</th>
          </tr>
        </thead>
        <tbody>
          <tr>
            <td>6 марта</td>
            <td>Казань за два дня</td>
            <td>Анна Лебедева</td>
            <td>9</td>
          </tr>
          <tr>
            <td>13 марта</td>
            <td>Карелия: Кивач и Рускеала</td>
            <td>Игорь Панов</td>
            <td>4</td>
          </tr>
          <tr>
            <td>20 марта</td>
            <td>Байкал зимой</td>
            <td>Мария Осипова</td>
            <td>12</td>
          </tr>
          <tr>
            <td>27 марта</td>
            <td>Горный Алтай</td>
            <td>Игорь Панов</td>
            <td>2</td>
          </tr>
        </tbody>
      </table>

      <h2 class="section-title" id="how">Как проходит поездка</h2>
      <ol class="steps">
        <li class="steps__item">Бронируете место на сайте и получаете подтверждение на телефон.</li>
        <li class="steps__item">Вносите предоплату 20 % — она закрепляет место в группе.</li>
        <li class="steps__item">За сутки до выезда гид присылает список вещей и точное время сбора.</li>
        <li class="steps__item">Выезжаете с группой, экскурсии и трансферы — по программе тура.</li>
      </ol>
    </main>

    <aside class="sidebar">
      <h2 class="sidebar__title">Коротко</h2>
      <ul class="facts">
        <li>Группы до 16 человек</li>
        <li>Проживание и завтраки включены</li>
        <li>Детям до 12 лет — скидка 15 %</li>
        <li>Гид сопровождает всю поездку</li>
      </ul>
      <p class="sidebar__note">Бронирование закрывается за 3 дня до выезда.</p>
    </aside>

    <section class="booking" id="booking">
      <h2 class="section-title">Бронирование тура</h2>
      <form class="form" action="#" method="post">
        <label class="form__field">
          <span class="form__label">Имя и фамилия</span>
          <input class="form__input" type="text" name="name" placeholder="Анна Лебедева" required>
        </label>
        <label class="form__field">
          <span class="form__label">Телефон</span>
          <input class="form__input" type="tel" name="phone" placeholder="+7 900 000-00-00" required>
        </label>
        <label class="form__field">
          <span class="form__label">Тур</span>
          <select class="form__input" name="tour" required>
            <option value="">Выберите направление</option>
            <option>Горный Алтай — 27 марта</option>
            <option>Байкал зимой — 20 марта</option>
            <option>Казань за два дня — 6 марта</option>
            <option>Карелия: Кивач и Рускеала — 13 марта</option>
          </select>
        </label>
        <label class="form__field">
          <span class="form__label">Количество человек</span>
          <input class="form__input" type="number" name="people" value="1" min="1" max="16" required>
        </label>
        <label class="form__field form__field--wide">
          <span class="form__label">Пожелания</span>
          <textarea class="form__input" name="comment" rows="3" placeholder="Едем с ребёнком 10 лет, нужны места рядом"></textarea>
        </label>
        <label class="checkbox form__field--wide">
          <input type="checkbox" name="agree" required>
          <span>Согласен на обработку персональных данных</span>
        </label>
        <button class="button form__submit" type="submit">Отправить заявку</button>
      </form>
    </section>

    <footer class="footer">
      <div class="footer__column">
        <h3 class="footer__title">Бюро «Компас»</h3>
        <p>Учебный проект студентов колледжа</p>
      </div>
      <div class="footer__column">
        <h3 class="footer__title">Офис</h3>
        <p>г. Самара, ул. Ленинградская, 1<br>ежедневно с 10:00 до 19:00</p>
      </div>
      <div class="footer__column">
        <h3 class="footer__title">Связь</h3>
        <p><a href="mailto:tour@example.ru">tour@example.ru</a><br><a href="tel:+79000000000">+7&nbsp;900&nbsp;000&#8209;00&#8209;00</a></p>
      </div>
    </footer>

  </div>

</body>
</html>

