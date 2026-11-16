/* Задание 3. Закреплённая шапка и меню */

.header {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-between;
  align-items: center;
  gap: 10px 20px;

  position: sticky;
  top: 0;
  z-index: 100;

  margin-inline: calc(var(--gap) * -1);
  padding: 14px var(--gap);

  background: var(--color-surface);
  border-bottom: 1px solid var(--color-border);
}

/* Логотип */
.logo {
  color: var(--color-text);
  text-decoration: none;
}

.logo__mark {
  color: var(--color-accent);
}

/* Список меню */
.nav__list {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  gap: 18px;

  margin: 0;
  padding: 0;
  list-style: none;
}

/* Ссылки меню */
.nav__list a {
  position: relative;
  display: inline-block;

  color: var(--color-text);
  text-decoration: none;

  transition: color 0.25s ease;
}

/* Анимированное подчёркивание */
.nav__list a::after {
  content: "";

  position: absolute;
  left: 0;
  bottom: -2px;

  width: 100%;
  height: 2px;
  background: var(--color-accent);

  transform: scaleX(0);
  transform-origin: left;
  transition: transform 0.25s ease;
}

.nav__list a:hover,
.nav__list a:focus-visible {
  color: var(--color-accent);
}

.nav__list a:hover::after,
.nav__list a:focus-visible::after {
  transform: scaleX(1);
}

.nav__list a:focus-visible {
  outline: 2px solid var(--color-accent);
  outline-offset: 5px;
}
