const editButton = document.createElement('button');
editButton.type = 'button';
editButton.textContent = 'Редактировать';
editButton.style.marginRight = '8px';

editButton.addEventListener('click', () => {
  openEditDialog(appointment);
});

actionCell.append(editButton);
