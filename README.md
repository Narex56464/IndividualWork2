:root {
  color-scheme: light;

  --page-bg: #f3f5f9;
  --panel-bg: #ffffff;
  --text-color: #202938;
  --field-bg: #ffffff;
  --border-color: #ccd3df;
  --accent-color: #315ee8;
  --accent-hover: #244bc7;
  --button-text: #ffffff;
  --link-color: #315ee8;
  --table-heading: #eaf0ff;
  --row-border: #e5e9f0;
  --secondary-bg: #5c6575;
  --error-color: #b42318;
  --focus-color: #315ee8;
}

:root[data-theme="dark"] {
  color-scheme: dark;

  --page-bg: #090f0c;
  --panel-bg: #121d17;
  --text-color: #e8f5ec;
  --field-bg: #18271e;
  --border-color: #42624e;
  --accent-color: #4ade80;
  --accent-hover: #86efac;
  --button-text: #082312;
  --link-color: #86efac;
  --table-heading: #203d2a;
  --row-border: #304d3a;
  --secondary-bg: #344d3e;
  --error-color: #ffb4ab;
  --focus-color: #86efac;
}

html body {
  background: var(--page-bg);
  color: var(--text-color);
}

html body main,
html body .table-wrapper,
html body #edit-dialog {
  background: var(--panel-bg);
  color: var(--text-color);
}

html body a {
  color: var(--link-color);
}

html body th {
  background: var(--table-heading);
  color: var(--text-color);
}

html body th,
html body td {
  border-bottom-color: var(--row-border);
}

html body input,
html body select,
html body #edit-form input:not([type="hidden"]),
html body #edit-form select {
  background: var(--field-bg);
  color: var(--text-color);
  border-color: var(--border-color);
}

html body input::placeholder {
  color: var(--text-color);
  opacity: 0.65;
}

html body button {
  background: var(--accent-color);
  color: var(--button-text);
}

html body button:hover:not(:disabled) {
  background: var(--accent-hover);
}

html body #edit-cancel {
  background: var(--secondary-bg);
  color: #ffffff;
}

html body #edit-message {
  color: var(--error-color);
}

html body :is(button, input, select, a):focus-visible {
  outline: 3px solid var(--focus-color);
  outline-offset: 3px;
}

html body #theme-toggle {
  width: auto;
  margin: 0;
  padding: 10px 16px;
  border: 1px solid var(--border-color);
  border-radius: 8px;
  font: inherit;
  cursor: pointer;
}

.theme-toolbar {
  display: flex;
  justify-content: flex-end;
  margin-bottom: 20px;
}
