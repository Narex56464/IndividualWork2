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
