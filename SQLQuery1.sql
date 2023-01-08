--UPDATE [Order] SET complete = 'true' WHERE id = 9


--SELECT id, shopperUserId, orderSubmitted, pickupDate, employeeUserId, inStore, complete FROM [Order] WHERE shopperUserId =3 AND orderSubmitted IS NOT Null;

SELECT o.id AS OrderID, o.shopperUserId, o.orderSubmitted, o.pickupDate, o.employeeUserId, o.inStore, o.complete, oi.id AS OrderItemID, oi.orderId, oi.itemId, i.id AS ItemID, i.item, i.categoryId, i.[weight], i.foodTypeId, i.[image], i.quantity  
                                    FROM [Order] o
                                    LEFT JOIN OrderItem oi ON oi.orderId = o.id
                                    LEFT JOIN Item i ON oi.itemId = i.id
                                    WHERE o.id = 10
                                    ORDER BY i.id
