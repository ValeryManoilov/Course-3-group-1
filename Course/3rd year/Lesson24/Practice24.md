*Практика A*

1
```sql
SELECT customers.customer_name, products.product_name, order_details.quantity, orders.order_date
FROM order_details
INNER JOIN products ON products.id = order_details.product_id
INNER JOIN orders ON orders.id = order_details.order_id
INNER JOIN customers ON customers.id = orders.customer_id;
```

2
```sql
SELECT *
FROM customers
LEFT JOIN orders ON orders.customer_id = customers.id;
```

3
```sql
SELECT *
FROM products
LEFT JOIN order_details ON order_details.product_id = products.id
LEFT JOIN orders ON orders.id = order_details.order_id;
```


4
```sql
SELECT customers.customer_name, products.product_name
FROM order_details
INNER JOIN orders ON orders.id = order_details.order_id
INNER JOIN customers ON customers.id = orders.customer_id
INNER JOIN products ON products.id = order_details.product_id;
```

*Практика B*

1
```sql
SELECT *
FROM products
INNER JOIN categories ON categories.id = products.category_id;
```

2
```sql
SELECT customers.customer_name, SUM(price)
FROM order_details
INNER JOIN orders ON orders.id = order_details.order_id
INNER JOIN customers ON orders.customer_id = customers.id
INNER JOIN products ON order_details.product_id = products.id
GROUP BY customers.customer_name
HAVING SUM(price) > 100;
```

3
```sql
SELECT *
FROM products
LEFT JOIN order_details ON order_details.product_id = products.id
LEFT JOIN orders ON orders.id = order_details.order_id;
```

*Практика C*

1
```sql
SELECT products.id, products.product_name
FROM products
FULL OUTER JOIN order_details ON order_details.product_id = products.id
WHERE order_details.id IS NULL;
```

2
```sql
SELECT customers.customer_name, products.product_name
FROM order_details
FULL OUTER JOIN orders ON orders.id = order_details.order_id
FULL OUTER JOIN customers ON customers.id = orders.customer_id
FULL OUTER JOIN products ON products.id = order_details.product_id;
```

3
```sql
SELECT orders.id, products.product_name
FROM orders
CROSS JOIN products
WHERE products.category_id != (SELECT id FROM categories WHERE categories.category_name = 'Электроника');
```