    #edit-dialog {
      box-sizing: border-box;
      width: min(460px, calc(100% - 32px));
      max-height: calc(100vh - 48px);
      overflow-y: auto;
      padding: 24px;
      border: none;
      border-radius: 12px;
      color: #202938;
    }

    #edit-dialog::backdrop {
      background: rgba(0, 0, 0, 0.45);
    }

    #edit-form {
      display: grid;
      gap: 12px;
    }

    #edit-title {
      margin: 0 0 8px;
    }

    #edit-form input:not([type="hidden"]),
    #edit-form select {
      box-sizing: border-box;
      width: 100%;
      padding: 10px;
      border: 1px solid #ccd3df;
      border-radius: 6px;
      font: inherit;
    }

    .edit-actions {
      display: flex;
      flex-wrap: wrap;
      gap: 10px;
    }

    #edit-cancel {
      background: #5c6575;
    }

    #edit-message {
      margin: 0;
      color: #b42318;
    }
