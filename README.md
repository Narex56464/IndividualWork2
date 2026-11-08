(() => {
  const storageKey = 'booking-site-theme';
  const root = document.documentElement;

  function applyTheme(value) {
    const theme = value === 'dark' ? 'dark' : 'light';

    root.dataset.theme = theme;

    const button = document.getElementById('theme-toggle');

    if (button) {
      button.textContent = theme === 'dark'
        ? 'Включить светлую тему'
        : 'Включить тёмную тему';

      button.setAttribute(
        'aria-pressed',
        String(theme === 'dark')
      );
    }
  }

  let savedTheme = 'light';

  try {
    savedTheme = localStorage.getItem(storageKey) || 'light';
  } catch {
    savedTheme = 'light';
  }

  applyTheme(savedTheme);

  document.addEventListener('DOMContentLoaded', () => {
    applyTheme(root.dataset.theme);

    const button = document.getElementById('theme-toggle');

    if (!button) {
      return;
    }

    button.addEventListener('click', () => {
      const nextTheme = root.dataset.theme === 'dark'
        ? 'light'
        : 'dark';

      applyTheme(nextTheme);

      try {
        localStorage.setItem(storageKey, nextTheme);
      } catch {
        // Переключение работает и без сохранения.
      }
    });
  });

  window.addEventListener('storage', (event) => {
    if (event.key === storageKey || event.key === null) {
      applyTheme(event.newValue);
    }
  });
})();
