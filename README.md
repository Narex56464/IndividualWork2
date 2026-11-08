  <dialog id="edit-dialog" aria-labelledby="edit-title">
    <form id="edit-form">
      <h2 id="edit-title">Редактирование записи</h2>

      <input id="edit-id" type="hidden">

      <label for="edit-name">Имя клиента</label>
      <input
        id="edit-name"
        type="text"
        minlength="2"
        maxlength="100"
        required
      >

      <label for="edit-phone">Телефон</label>
      <input
        id="edit-phone"
        type="tel"
        minlength="5"
        maxlength="30"
        required
      >

      <label for="edit-specialist">Специалист</label>
      <select id="edit-specialist" required></select>

      <label for="edit-date">Дата</label>
      <input id="edit-date" type="date" required>

      <label for="edit-time">Время</label>
      <select id="edit-time" required>
        <option value="09:00">09:00</option>
        <option value="10:00">10:00</option>
        <option value="11:00">11:00</option>
        <option value="12:00">12:00</option>
        <option value="13:00">13:00</option>
        <option value="14:00">14:00</option>
        <option value="15:00">15:00</option>
        <option value="16:00">16:00</option>
        <option value="17:00">17:00</option>
        <option value="18:00">18:00</option>
        <option value="19:00">19:00</option>
      </select>

      <p id="edit-message" role="status" aria-live="polite"></p>

      <div class="edit-actions">
        <button id="edit-save" type="submit" disabled>
          Сохранить
        </button>

        <button id="edit-cancel" type="button">
          Отмена
        </button>
      </div>
    </form>
  </dialog>
