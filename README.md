A schema of the database design

**Order**

OrderId,
Region,
DateofSale,
ShippingCost,
PaymentMethod

**OrderItem**

Id,
OrderId,
ProductId,
QuantitySold,
UnitPrice,
Discount,
Product

**ProductId**

ProductName,
Category


**Customer**

CustomerId,
CustomerName,
CustomerEmail,
CustomerAddress

**Revenue calcuation**

TotalRevenue
/api/sales/total?from=01/01/2020&to=01/01/2026

TotalRevenueByProduct
/api/sales/product?from=01/01/2020&to=01/01/2026

TotalRevenueByCategory
/api/sales/category?from=01/01/2020&to=01/01/2026

TotalRevenueByRegion
/api/sales/region?from=01/01/2020&to=01/01/2026

**Instructions**

Add-migration inital

Update-Database

**Import csv :**

/api/csv/import

