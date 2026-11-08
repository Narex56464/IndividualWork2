let editSaving = false;

editDialog.addEventListener('cancel', (event) => {
  if (editSaving) {
    event.preventDefault();
  }
});

editForm.addEventListener('submit', async (event) => {
  event.preventDefault();

  if (editSaving || editSave.disabled) {
    return;
  }

  if (!editForm.reportValidity()) {
    return;
  }

  const id = editId.value;

  const payload = {
    specialist_id: Number(editSpecialist.value),
    client_name: editName.value.trim(),
    client_phone: editPhone.value.trim(),
    appointment_date: editDate.value,
    appointment_time: editTime.value
  };

  editSaving = true;

  const controls = Array.from(
    editForm.querySelectorAll('input, select, button')
  );

  const previousDisabled = controls.map(
    (control) => control.disabled
  );

  for (const control of controls) {
    control.disabled = true;
  }

  editMessage.textContent = 'Сохраняем изменения...';

  try {
    const response = await fetch(
      '/api/admin/appointments/' + encodeURIComponent(id),
      {
        method: 'PATCH',
        credentials: 'same-origin',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
      }
    );

    if (response.status === 401) {
      throw new Error(
        'Вход не выполнен. Обновите страницу и войдите снова.'
      );
    }

    const result = await response.json();

    if (!response.ok) {
      throw new Error(
        result.error || 'Не удалось сохранить изменения.'
      );
    }

    editDialog.close();
    await loadAppointments();
  } catch (error) {
    editMessage.textContent = error.message;
  } finally {
    controls.forEach((control, index) => {
      control.disabled = previousDisabled[index];
    });

    editSaving = false;
  }
});
