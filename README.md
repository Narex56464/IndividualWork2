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
