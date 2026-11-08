(() => {
  function formatPhone(value) {
    const digits = String(value).replace(/\D/g, '').slice(0, 11);

    if (!digits) {
      return '';
    }

    let result = '+' + digits[0];

    if (digits.length > 1) {
      result += '(' + digits.slice(1, 4);
    }

    if (digits.length > 4) {
      result += ')-' + digits.slice(4, 7);
    }

    if (digits.length > 7) {
      result += '-' + digits.slice(7, 9);
    }

    if (digits.length > 9) {
      result += '-' + digits.slice(9, 11);
    }

    return result;
  }

  document.querySelectorAll('[data-phone-mask]').forEach((input) => {
    input.addEventListener('input', () => {
      const oldValue = input.value;
      const oldPosition = input.selectionStart ?? oldValue.length;

      const digitsBeforeCursor = oldValue
        .slice(0, oldPosition)
        .replace(/\D/g, '')
        .length;

      const formatted = formatPhone(oldValue);
      input.value = formatted;

      let position = formatted.length;
      let digitCount = 0;

      for (let i = 0; i < formatted.length; i++) {
        if (/\d/.test(formatted[i])) {
          digitCount++;
        }

        if (digitCount === digitsBeforeCursor) {
          position = i + 1;
          break;
        }
      }

      input.setSelectionRange(position, position);
    });

    input.addEventListener('beforeinput', (event) => {
      if (event.inputType !== 'deleteContentBackward') {
        return;
      }

      const start = input.selectionStart;
      const end = input.selectionEnd;

      if (start === null || start !== end || start === 0) {
        return;
      }

      if (/\d/.test(input.value[start - 1])) {
        return;
      }

      let position = start - 1;

      while (position >= 0 && !/\d/.test(input.value[position])) {
        position--;
      }

      if (position < 0) {
        return;
      }

      event.preventDefault();

      input.setRangeText('', position, start, 'end');
      input.dispatchEvent(new Event('input', { bubbles: true }));
    });

    input.addEventListener('blur', () => {
      input.value = formatPhone(input.value);
    });
  });
})();
