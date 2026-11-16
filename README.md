/* Задание 5. Карточки туров */

/* Заголовки разделов */
.section-title {
  margin-bottom: 20px;

  font-size: 1.5rem;
  line-height: 1.3;
}

.content > .section-title:not(:first-child) {
  margin-top: 36px;
}

/* Сетка карточек */
.tours {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
  gap: var(--gap);
}

/* Карточка */
.tour {
  display: flex;
  flex-direction: column;
  min-width: 0;

  overflow: hidden;
  border: 1px solid var(--color-border);
  border-radius: var(--radius);

  background: var(--color-surface);
  box-shadow: var(--shadow);

  transition:
    transform 0.25s ease,
    box-shadow 0.25s ease;
}

.tour:hover {
  transform: translateY(-4px);
  box-shadow: 0 8px 24px rgba(28, 31, 43, 0.16);
}

/* Фотография */
.tour__photo {
  display: block;
  width: 100%;
  height: auto;
  aspect-ratio: 4 / 3;
  object-fit: cover;
}

/* Текстовая часть карточки */
.tour__body {
  position: relative;

  display: flex;
  flex-direction: column;
  flex: 1;
  gap: 12px;

  padding: 20px;
}

/* Метка расположена над текстом, в углу фотографии */
.tour__tag {
  position: absolute;
  top: -14px;
  right: 14px;

  padding: 4px 12px;
  border-radius: 999px;

  color: white;
  background: var(--color-accent);

  font-size: 0.8rem;
  font-weight: 700;
}

/* Название тура */
.tour__title {
  font-size: 1.2rem;
  line-height: 1.3;
}

/* Описание */
.tour__text {
  color: var(--color-muted);
}

/* Длительность и цена — внизу карточки */
.tour__meta {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: center;
  gap: 8px;

  margin-top: auto;
  padding-top: 12px;

  border-top: 1px solid var(--color-border);
}

.tour__price {
  color: var(--color-primary);
  font-weight: 700;
}
