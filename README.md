<body>
  <main>
    <header>
      <h1>Записи клиентов</h1>
      <button id="refresh" type="button">Обновить</button>
    </header>

    <p>
      <a href="/index.html">Открыть страницу записи</a>
    </p>

    <p id="message" role="status" aria-live="polite">
      Загружаем записи...
    </p>

    <div class="table-wrapper">
      <table>
        <thead>
          <tr>
            <th scope="col">Номер</th>
            <th scope="col">Клиент</th>
            <th scope="col">Телефон</th>
            <th scope="col">Специалист</th>
            <th scope="col">Дата</th>
            <th scope="col">Время</th>
            <th scope="col">Действия</th> 
          </tr>
        </thead>
        <tbody id="appointments"></tbody>
      </table>
    </div>
  </main>

  <script>
