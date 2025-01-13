Практика А
1
```sql
SELECT * 
FROM employees
WHERE salary > 70000;
```
2
```sql
SELECT * 
FROM employees
WHERE position = 'Разработчик';
```
3
```sql
SELECT * 
FROM employees
WHERE department_id = (SELECT id FROM departments WHERE department_name = 'Разработка')
ORDER BY name ASC;
```

Практика B
1
```sql
SELECT * 
FROM employees
WHERE salary = 72000
ORDER BY name DESC
```
2
```sql
SELECT * 
FROM employees
WHERE salary BETWEEN 60000 AND 80000
ORDER BY name DESC
```
3
```sql
SELECT * 
FROM employees
WHERE department_id = 3
ORDER BY salary ASC;
```

