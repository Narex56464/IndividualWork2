/* Подвал сайта */

.footer {
  display: grid;
  grid-template-columns: minmax(0, 1fr);
  gap: var(--gap);

  margin-top: 10px;
  padding: 24px;

  border-top: 1px solid var(--color-border);
  border-radius: var(--radius);

  background: var(--color-surface);
}

.footer__column {
  min-width: 0;
}

.footer__title {
  margin-bottom: 8px;

  font-size: 1rem;
  color: var(--color-text);
}

.footer p {
  color: var(--color-muted);
  font-size: 0.9rem;
}

.footer a {
  color: var(--color-primary);
  text-underline-offset: 3px;
  overflow-wrap: anywhere;
}

.footer a:hover {
  color: var(--color-accent);
}

/* На широком экране — три колонки */
@media (min-width: 700px) {
  .footer {
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }
}
