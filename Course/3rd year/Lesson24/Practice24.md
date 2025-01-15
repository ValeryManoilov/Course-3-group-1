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

