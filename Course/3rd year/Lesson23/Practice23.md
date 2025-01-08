(Выполнял в pgAdmin4)

Создание таблицы для работы с данными:

```sql
CREATE TABLE departments (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    department_name TEXT NOT NULL
);

CREATE TABLE employees (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    name TEXT NOT NULL,
    department_id INTEGER,
    position TEXT,
    salary REAL,
    FOREIGN KEY (department_id) REFERENCES departments(id)
);

INSERT INTO departments (id, department_name) VALUES 
(1, 'Маркетинг'),
(2, 'Разработка'),
(3, 'Продажи'),
(4, 'HR');

INSERT INTO employees (id, name, department_id, position, salary) VALUES 
(1, 'Иван Иванов', 2, 'Разработчик', 80000),
(2, 'Анна Смирнова', 1, 'Маркетолог', 60000),
(3, 'Петр Петров', 3, 'Менеджер по продажам', 70000),
(4, 'Мария Кузнецова', 4, 'HR-специалист', 50000),
(5, 'Ольга Сидорова', 2, 'Тестировщик', 55000),
(6, 'Алексей Федоров', 2, 'Разработчик', 85000),
(7, 'Елена Захарова', 1, 'Маркетолог', 62000),
(8, 'Дмитрий Орлов', 3, 'Менеджер по продажам', 72000);
```


*Практика A*
-
Грязное чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

UPDATE employees SET name = 'Андрей Шапошников' WHERE id = 2;

SELECT pg_sleep(20);

ROLLBACK;

SELECT * FROM employees;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

SELECT * FROM employees;

COMMIT;
```

Обе транзакции запускаются обновременно.
Так как в postgresql как такового read uncommitted не существует, то результат такой же, какой бы был при read commited,
т. е. после завершения транзакций они выдали изначальные данные (Анна Смирнова).


Неповторяющееся чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

SELECT * FROM employees WHERE id = 4;

SELECT pg_sleep(15);

SELECT * FROM employees WHERE id = 4;

-- COMMIT;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

UPDATE employees SET name = 'Артем Анафриев' WHERE id = 4;

COMMIT;
```

Сначала запускалась первая транзакция, сразу за ней вторая.
В итоге до изменений в первом выводе было "Мария Кузнецова", а во втором "Артем Анафриев". Иначе говоря,
изоляция read commited не спасла от неповторяющегося чтения, что и должно было случиться.


Фантомное чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

SELECT COUNT(*) FROM employees;

SELECT pg_sleep(15);

SELECT COUNT(*) FROM employees;

-- COMMIT;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL READ COMMITTED;

DELETE FROM employees WHERE id = 6;

COMMIT;
```

Сначала запускалась первая транзакция, за ней вторая.
Первый вывод - 8, второй вывод - 7. Итог - read commited не спасает от фантомного чтения


*Практика B*
-

Грязное чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

UPDATE employees SET name = 'Иван Горинов' WHERE id = 7;

SELECT pg_sleep(10);

ROLLBACK;

SELECT * FROM employees;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

SELECT * FROM employees;

COMMIT;
```

Обе транзакции запускаются обновременно.
В итоге repeatable read спас от грязного чтения


Неповторяющееся чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

SELECT * FROM employees;

SELECT pg_sleep(15);

SELECT * FROM employees;

COMMIT;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

UPDATE employees SET name = 'Геннадий Астапов' WHERE id = 8;

COMMIT;
```

Сначала запускалась первая, за ней вторая.
В итоге repeatable read спас от неповторяющегося чтения, и данные, в отличии от read committed, не изменились


Фантомное чтение

Первая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

SELECT COUNT(*) FROM employees;

SELECT pg_sleep(15);

SELECT COUNT(*) FROM employees;

COMMIT;
```

Вторая транзакция
```sql
BEGIN;
SET TRANSACTION ISOLATION LEVEL REPEATABLE READ;

DELETE FROM employees WHERE id = 6;

COMMIT;
```

Так как в postgresql уровни изоляции работают немного по другому, repeatable read спас и от фантомного чтения,
хотя в обычном sql этого бы не произошло (я сам около часа пытался разобраться как так вышло).


*Практика С*
-

Грязное и неповторяющееся чтение
По аналогии с предыдущими, serializable будет спасать от этих ошибок. Код аналогичный, но изменен уровень изоляции

Фантомное чтение

Первая транзакция
```sql
BEGIN;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SELECT COUNT(*) FROM employees;

SELECT pg_sleep(15);

SELECT COUNT(*) FROM employees;

-- COMMIT;
```

Вторая транзакция
```sql
BEGIN;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

DELETE FROM employees WHERE id = 1;
-- INSERT INTO employees (id, name, department_id, position, salary) 
-- VALUES (1, 'Иван Иванов', 2, 'Разработчик', 80000);

COMMIT;
```

В итоге уровень Serializable спас от фантомного чтения  