:root {
  --color-bg: #f3f4f8;
  --color-surface: #ffffff;
  --color-text: #1c1f2b;
  --color-muted: #5d6478;
  --color-primary: #2f4b8f;
  --color-accent: #c2410c;
  --color-border: #dcdfea;
  --radius: 10px;
  --shadow: 0 2px 10px rgba(28, 31, 43, 0.08);
  --gap: 20px;
}

*,
*::before,
*::after {
  box-sizing: border-box;
}

* {
  margin: 0;
  padding: 0;
}

body {
  font-family: Arial, sans-serif;
  font-size: 16px;
  line-height: 1.6;
  color: var(--color-text);
  background: var(--color-bg);
}
.menu a {
  position: relative;
  color: var(--color-text);
  transition: color 0.3s;
}
.menu a::after {
  content: "";
  position: absolute;
  left: 0;
  bottom: -2px;
  width: 100%;
  height: 2px;
  background: var(--color-accent);
  transform: scaleX(0);
  transform-origin: left;
  transition: transform 0.3s;
}
.menu a:hover {
  color: var(--color-primary);
}
.menu a:hover::after {
  transform: scaleX(1);
}

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

.logo {
  color: var(--color-text);
  text-decoration: none;
}

.logo__mark {
  color: var(--color-accent);
}

.nav__list {
  display: flex;
  flex-wrap: wrap;
  align-items: center;
  gap: 18px;

  margin: 0;
  padding: 0;
  list-style: none;
}

.nav__list a {
  position: relative;
  display: inline-block;

  color: var(--color-text);
  text-decoration: none;

  transition: color 0.25s ease;
}

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
