require('dotenv').config();

const express = require('express');
const mysql = require('mysql2/promise');

const app = express();

app.use(express.json());
app.use(express.static(require('path').join(__dirname, 'public')));

const pool = mysql.createPool({
  host: process.env.DB_HOST,
  user: process.env.DB_USER,
  password: process.env.DB_PASSWORD,
  database: process.env.DB_NAME,
  port: 3306,
  connectionLimit: 3,
  dateStrings: true
});

app.get('/', (req, res) => {
  res.json({
    message: 'Сервер сайта работает!',
    specialists: '/api/specialists'
  });
});

app.get('/api/specialists', async (req, res) => {
  try {
    const [rows] = await pool.query(
      'SELECT id, name, profession FROM specialists ORDER BY id'
    );

    res.json(rows);
  } catch (error) {
    console.error('Ошибка получения специалистов:', error.code);

    res.status(500).json({
      error: 'Не удалось получить список специалистов'
    });
  }
});
app.post('/api/appointments', async (req, res) => {
  const body = req.body || {};

  const specialistId = Number(body.specialist_id);

  const name = typeof body.client_name === 'string'
    ? body.client_name.trim()
    : '';

  const phone = typeof body.client_phone === 'string'
    ? body.client_phone.trim()
    : '';

  const date = typeof body.appointment_date === 'string'
    ? body.appointment_date
    : '';

  const time = typeof body.appointment_time === 'string'
    ? body.appointment_time
    : '';

  if (
    !Number.isInteger(specialistId) ||
    specialistId <= 0 ||
    name.length < 2 ||
    name.length > 100 ||
    phone.length < 5 ||
    phone.length > 30
  ) {
    return res.status(400).json({
      error: 'Выберите специалиста, укажите имя и телефон.'
    });
    
  }

  const parsedDate = new Date(date + 'T00:00:00Z');

  const validDate =
    /^\d{4}-\d{2}-\d{2}$/.test(date) &&
    Number.isFinite(parsedDate.getTime()) &&
    parsedDate.toISOString().slice(0, 10) === date &&
    Number(date.slice(0, 4)) >= 1000;

  const validTime = /^([01]\d|2[0-3]):[0-5]\d$/.test(time);

  if (!validDate || !validTime) {
    return res.status(400).json({
      error: 'Укажите корректные дату и время.'
    });
  }


  // Разрешаем начало приёма в 09:00–19:00.
  if (!/^(09|1[0-9]):00$/.test(time)) {
    return res.status(400).json({
      error: 'Выберите время с 09:00 до 19:00, ровно в начале часа.'
    });
  }

  // Определяем текущую дату и время именно по Москве.
  const moscowParts = new Intl.DateTimeFormat('en-GB', {
    timeZone: 'Europe/Moscow',
    year: 'numeric',
    month: '2-digit',
    day: '2-digit',
    hour: '2-digit',
    minute: '2-digit',
    hourCycle: 'h23'
  }).formatToParts(new Date());

  const moscow = {};

  for (const part of moscowParts) {
    moscow[part.type] = part.value;
  }

  const today =
    moscow.year + '-' + moscow.month + '-' + moscow.day;

  const currentTime =
    moscow.hour + ':' + moscow.minute;

  if (
    date < today ||
    (date === today && time <= currentTime)
  ) {
    return res.status(400).json({
      error: 'Это время уже прошло по Москве. Выберите будущую дату и время.'
    });
  }
  const weekday = parsedDate.getUTCDay();

if (weekday === 0 || weekday === 6) {
  return res.status(400).json({
    error: 'Приём только с понедельника по пятницу.'
  });
}
  try {
  const timeWithSeconds = time + ':00';

const [busySlots] = await pool.execute(
  "SELECT 1 FROM appointments WHERE specialist_id = ? AND appt_date = ? AND appt_time = ? LIMIT 1",
  [specialistId, date, timeWithSeconds]

);
console.log('Проверка занятого времени:', {
  specialistId,
  date,
  time,
  busySlots
});

if (busySlots.length > 0) {
  return res.status(409).json({
    error: 'Это время уже занято. Выберите другое.'
  });
}

 const [result] = await pool.execute(
  'INSERT INTO appointments ' +
  '(specialist_id, client_name, phone, ' +
  'appt_date, appt_time) ' +
  'VALUES (?, ?, ?, ?, ?)',
  [specialistId, name, phone, date, timeWithSeconds]

);

    return res.status(201).json({
      message: 'Запись успешно создана!',
      appointment_id: result.insertId
    });
  } catch (error) {
    if (error.code === 'ER_DUP_ENTRY') {
      return res.status(409).json({
        error: 'Это время уже занято. Выберите другое.'
      });
    }

    console.error(
  'Ошибка сохранения записи:',
  error.code,
  error.sqlMessage
);

    return res.status(500).json({
      error: 'Не удалось сохранить запись. Попробуйте позже.'
    });
  }
});
function requireAdmin(req, res, next) {
  res.set('Cache-Control', 'no-store');

  const adminUser = process.env.ADMIN_USER;
  const adminPassword = process.env.ADMIN_PASSWORD;

  if (!adminUser || !adminPassword) {
    return res.status(503).json({
      error: 'Настройки входа администратора не заполнены.'
    });
  }

  const authorization = req.get('Authorization') || '';

  if (authorization.startsWith('Basic ')) {
    const credentials = Buffer.from(
      authorization.slice(6),
      'base64'
    ).toString('utf8');

    const separator = credentials.indexOf(':');

    if (separator !== -1) {
      const user = credentials.slice(0, separator);
      const password = credentials.slice(separator + 1);

      if (user === adminUser && password === adminPassword) {
        return next();
      }
    }
  }

  res.set(
    'WWW-Authenticate',
    'Basic realm="Booking Admin", charset="UTF-8"'
  );

  return res.status(401).send('Требуется вход администратора.');
}

app.get('/api/admin/appointments', requireAdmin, async (req, res) => {
  try {
    const [rows] = await pool.query(
      'SELECT a.id, s.name AS specialist_name, ' +
      'a.client_name, a.phone, a.appt_date, a.appt_time, ' +
      'a.created_at ' +
      'FROM appointments AS a ' +
      'JOIN specialists AS s ON s.id = a.specialist_id ' +
      'ORDER BY a.appt_date DESC, a.appt_time DESC, a.id DESC'
    );

    res.json(rows);
  } catch (error) {
    console.error(
      'Ошибка просмотра записей:',
      error.code,
      error.sqlMessage
    );

    res.status(500).json({
      error: 'Не удалось загрузить записи.'
    });
  }
});
app.delete('/api/admin/appointments/:id', requireAdmin, async (req, res) => {
  try {
    const id = Number(req.params.id);

    if (!Number.isInteger(id) || id <= 0) {
      return res.status(400).json({
        error: 'Некорректный идентификатор записи.'
      });
    }

    const [result] = await pool.query(
      'DELETE FROM appointments WHERE id = ?',
      [id]
    );

    if (result.affectedRows === 0) {
      return res.status(404).json({
        error: 'Запись не найдена.'
      });
    }

    res.json({
      success: true
    });
  } catch (error) {
    console.error(
      'Ошибка удаления записи:',
      error.code,
      error.sqlMessage
    );

    res.status(500).json({
      error: 'Не удалось удалить запись.'
    });
  }
});

app.get('/api/availability', async (req, res) => {
  const { date, specialist_id } = req.query;

  if (
    typeof date !== 'string' ||
    !/^\d{4}-\d{2}-\d{2}$/.test(date)
  ) {
    return res.status(400).json({
      error: 'Укажите корректную дату.'
    });
  }

  if (
    typeof specialist_id !== 'string' ||
    !/^[1-9]\d*$/.test(specialist_id)
  ) {
    return res.status(400).json({
      error: 'Выберите специалиста.'
    });
  }

  try {
    const [rows] = await pool.execute(
      "SELECT appt_time FROM appointments WHERE appt_date = ? AND specialist_id = ?",
      [date, specialist_id]
    );

    const bookedTimes = rows.map(
      (row) => String(row.appt_time).slice(0, 5)
    );

    res.json({ bookedTimes });
  } catch (error) {
    console.error('Ошибка при получении занятых часов:', error);

    res.status(500).json({
      error: 'Не удалось получить расписание.'
    });
  }
});

app.get('/admin', requireAdmin, (req, res) => {
  res.sendFile(
    require('path').join(__dirname, 'admin', 'index.html')
  );
});

async function startServer() {
  try {
    await pool.query('SELECT 1');

    console.log('Подключение к MySQL успешно.');

    const port = Number(process.env.PORT) || 3000;

    const server = app.listen(port, '127.0.0.1', () => {
      console.log('Сайт: http://127.0.0.1:' + port);
    });

    server.on('error', (error) => {
      console.error('Ошибка запуска сервера:', error.code);
      process.exit(1);
    });
  } catch (error) {
    console.error('Не удалось подключиться к MySQL:', error.code);

    await pool.end();
    process.exitCode = 1;
  }
}

startServer();
}
