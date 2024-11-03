1. Выполните sql запрос из файла "SQL скрипт".
Напишите следующие запросы:
- запрос для выборки всех заказов с подробной информацией о клиентах и продуктах
- запрос для выборки всех клиентов и их заказов, включая клиентов без заказов
- запрос для выборки всех продуктов и заказов, включая продукты, которые не были заказаныэ
- запрос для выборки всех клиентов и продуктов

2. Напишите следующие запросы:
- запрос для выборки пар продуктов одной категории с разными ценами
- запрос, который вернет список клиентов и общую сумму, которую каждый клиент потратил на все свои заказы. Отобразите только тех клиентов, которые потратили более 100 единиц валюты
- запрос, который выведет всех клиентов, которые еще не сделали ни одного заказа и найдите тех клиентов, у которых нет связанных записей в таблице orders

3. Напишите следующие запросы:
- запрос, который выведет все продукты, которые не были куплены ни в одном заказе и отфильтруйте результаты, чтобы показать только те продукты, которые не имеют связанных записей в order_details
- запрос, который вернет полный список всех клиентов и продуктов, независимо от того, сделали ли клиенты заказы или были ли проданы продукты. Поскольку SQLite не поддерживает FULL OUTER JOIN, эмулируйте его с помощью UNION ALL для комбинации результатов LEFT JOIN и RIGHT JOIN
- запрос, который найдет все возможные комбинации продуктов для заказа, исключая продукты из категории "Электроника". Используйте CROSS JOIN, чтобы создать полное декартово произведение всех продуктов.