*Практика А*

Копирование кода
Тот же код, что и в файле Sql скрипт.txt

Анализ таблицы users
```sql
ANALYSE users;
EXPLAIN SELECT * FROM users;
```
Для таблицы users нужно создать уникальные индексы для полей username и email (их можно объединить в составной), так как они не повторяются


Анализ таблицы products
```sql
ANALYSE products;
EXPLAIN SELECT * FROM products;
```
Для таблицы products нужно создать уникальный индекс для поля productname, так как оно не может повторяться


Анализ таблицы orders
```sql
ANALYSE orders;
EXPLAIN SELECT * FROM orders;
```
Для таблицы orders нужно создать составной индекс для поля userid и productid. Уникальные индекся создать нельзя, 
так как один пользователь, например, может сделать несколько заказов, и в поле userid будут повторяющиеся значения


Анализ таблицы categories
```sql
ANALYSE categories;
EXPLAIN SELECT * FROM categories;
```
Для таблицы categories нужно создать уникальный индекс для поля category_name, так как оно не повторяется