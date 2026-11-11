<!DOCTYPE html>
<html lang="ru">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>ReelHub — лента видео</title>

    <style>
        * {
            box-sizing: border-box;
        }

        body {
            margin: 0;
            background: #101014;
            color: #ffffff;
            font-family: Arial, sans-serif;
        }

        header {
            padding: 20px;
            border-bottom: 1px solid #30303a;
        }

        .logo {
            margin: 0;
            font-size: 28px;
            color: #a78bfa;
        }

        main {
            max-width: 700px;
            margin: 60px auto;
            padding: 0 20px;
        }

        .card {
            padding: 30px;
            background: #1b1b24;
            border: 1px solid #30303a;
            border-radius: 20px;
        }

        h1 {
            margin-top: 0;
        }

        p {
            color: #c5c5d3;
            line-height: 1.6;
        }

        .status {
            display: inline-block;
            padding: 10px 16px;
            border-radius: 10px;
            background: #23392c;
            color: #a2e8b8;
        }
    </style>
</head>

<body>
    <header>
        <p class="logo">ReelHub</p>
    </header>

    <main>
        <section class="card">
            <h1>Твоя новая лента видео</h1>
            <p>
                Здесь можно будет смотреть ролики из Reddit,
                отмечать понравившиеся и собирать личное избранное.
            </p>
            <p class="status">Приложение запущено локально</p>
        </section>
    </main>
</body>
</html>
