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
Подбор товаров с максимальной и минимальной ценой в каждой категории
```sql
SELECT categories.category_name, 
        table1.price AS min_price, 
        table1.product_name AS min_price_product, 
        table2.price AS max_price, 
        table2.product_name AS max_price_product
FROM categories
INNER JOIN products ON products.category_id = categories.id
INNER JOIN (SELECT price, product_name
			FROM products 
			WHERE price IN (SELECT MIN(price)
							FROM products 
							GROUP BY category_id)) 
AS table1 ON table1.product_name = products.product_name
LEFT JOIN (SELECT price, category_id, product_name
			FROM products 
			WHERE price IN (SELECT MAX(price)
							FROM products 
							GROUP BY category_id)) 
AS table2 ON table2.category_id = products.category_id
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