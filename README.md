const editDialog = document.getElementById('edit-dialog');
const editForm = document.getElementById('edit-form');
const editId = document.getElementById('edit-id');
const editName = document.getElementById('edit-name');
const editPhone = document.getElementById('edit-phone');
const editSpecialist = document.getElementById('edit-specialist');
const editDate = document.getElementById('edit-date');
const editTime = document.getElementById('edit-time');
const editMessage = document.getElementById('edit-message');
const editSave = document.getElementById('edit-save');
const editCancel = document.getElementById('edit-cancel');

editCancel.addEventListener('click', () => {
  editDialog.close();
});

editForm.addEventListener('submit', (event) => {
  event.preventDefault();
});

async function openEditDialog(appointment) {
  editForm.reset();

  editId.value = appointment.id;
  editName.value = appointment.client_name || '';
  editPhone.value = appointment.phone || '';
  editDate.value = String(appointment.appt_date).slice(0, 10);
  editTime.value = String(appointment.appt_time).slice(0, 5);

  editSave.disabled = true;
  editMessage.textContent = 'Загружаем специалистов...';
  editSpecialist.replaceChildren();

  editDialog.showModal();

  try {
    const response = await fetch('/api/specialists', {
      credentials: 'same-origin',
      cache: 'no-store'
    });

    if (!response.ok) {
      throw new Error('Не удалось загрузить специалистов.');
    }

    const specialists = await response.json();

    if (!Array.isArray(specialists)) {
      throw new Error('Сервер вернул неожиданный ответ.');
    }

    for (const specialist of specialists) {
      const option = document.createElement('option');
      option.value = String(specialist.id);
      option.textContent = specialist.name;
      editSpecialist.append(option);
    }

    editSpecialist.value = String(appointment.specialist_id);

    if (!editSpecialist.value) {
      throw new Error(
        'Не удалось выбрать текущего специалиста. ' +
        'Проверьте, что API записей возвращает specialist_id.'
      );
    }

    editMessage.textContent =
      'Форма готова. Сохранение подключим следующим шагом.';
  } catch (error) {
    editMessage.textContent = error.message;
  }
}
