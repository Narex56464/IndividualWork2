from flask import Flask

app = Flask(__name__)


@app.route("/")
def home():
    return """
    <!DOCTYPE html>
    <html lang="ru">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>ReelHub</title>
    </head>
    <body style="background: #111; color: white; font-family: Arial;
                 text-align: center; padding: 60px 20px;">
        <h1>ReelHub</h1>
        <p>Моё приложение для просмотра видео.</p>
        <p>Сервер работает! Первый шаг выполнен.</p>
    </body>
    </html>
    """


if __name__ == "__main__":
    app.run(host="127.0.0.1", port=5000)
