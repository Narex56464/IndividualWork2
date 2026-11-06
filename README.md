          for (const value of values) {
            const cell = document.createElement('td');
            cell.textContent = value == null ? '' : String(value);
            row.append(cell);
          }

          const actionCell = document.createElement('td');

          const deleteButton = document.createElement('button');
          deleteButton.type = 'button';
          deleteButton.textContent = 'Удалить';

          deleteButton.addEventListener('click', async () => {
            const confirmed = confirm(
              'Удалить запись №' + appointment.id + '?'
            );

            if (!confirmed) {
              return;
            }

            deleteButton.disabled = true;

            try {
              const response = await fetch(
                '/api/admin/appointments/' + appointment.id,
                {
                  method: 'DELETE',
                  credentials: 'same-origin'
                }
              );

              const result = await response.json();

              if (!response.ok) {
                throw new Error(
                  result.error || 'Не удалось удалить запись.'
                );
              }

              await loadAppointments();
            } catch (error) {
              alert(
                'Не удалось удалить запись. ' + error.message
              );
            } finally {
              deleteButton.disabled = false;
            }
          });

          actionCell.append(deleteButton);
          row.append(actionCell);

          tbody.append(row);
          for (const value of values) {
            const cell = document.createElement('td');
            cell.textContent = value == null ? '' : String(value);
            row.append(cell);
          }

          tbody.append(row);
        }
        message.textContent = result.length === 0
          ? 'Записей пока нет.'
          : 'Всего записей: ' + result.length;
      } catch (error) {
        message.textContent =
          'Не удалось обновить список. ' + error.message;
      } finally {
        refresh.disabled = false;
      }
    }

    refresh.addEventListener('click', loadAppointments);
    loadAppointments();
  </script>
}
