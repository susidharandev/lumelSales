using lumelSales.Data;
using lumelSales.Models;
using Microsoft.EntityFrameworkCore;

namespace lumelSales.Service
{
    public class CsvImportService
    {
        private readonly AppDbContext _dbContext;
        public CsvImportService(AppDbContext appDbContext) 
        { 
            _dbContext = appDbContext;
        }
        public async Task ImportCsv()
        {
            var path = "Data/Sales.csv";
            if (!File.Exists(path)) return;

            using StreamReader sr = new StreamReader(path);
            var data = await sr.ReadLineAsync();

            int batchcount = 500;
            int count = 0;

            var exitingCustomerIds = await _dbContext.Customers.Select(c => c.CustomerId).ToHashSetAsync();
            var exitingOrdersId = await _dbContext.Orders.Select(c => c.OrderId).ToHashSetAsync();
            var exitingProductsIds = await _dbContext.Products.Select(c => c.ProductId).ToHashSetAsync();

            while (!sr.EndOfStream)
            {
                var line = await sr.ReadLineAsync();

                var columns = line.Split(',');

                var _OrderId = int.Parse(columns[0]);
                var _ProductId = columns[1];
                var _CustomerId = columns[2];
                var _ProductName = columns[3];
                var _Category = columns[4];
                var _Region = columns[5];
                var _DateofSale = DateTime.Parse(columns[6]);
                var _QuantitySold = int.Parse(columns[7]);
                var _UnitPrice = decimal.Parse(columns[8]);
                var _Discount = decimal.Parse(columns[9]);
                var _ShippingCost = decimal.Parse(columns[10]);
                var _PaymentMethod = columns[11];
                var _CustomerName = columns[12];
                var _CustomerEmail = columns[13];
                var _CustomerAddress = columns[13];

                if (!exitingCustomerIds.Contains(_CustomerId))
                {
                    _dbContext.Customers.Add(new Customer
                    {
                        CustomerId = _CustomerId,
                        CustomerAddress = _CustomerAddress,
                        CustomerEmail = _CustomerEmail,
                        CustomerName = _CustomerName
                    });
                    exitingCustomerIds.Add(_CustomerId);
                }
                if (!exitingOrdersId.Contains(_OrderId))
                {
                    _dbContext.Orders.Add(new Order
                    {
                        OrderId = _OrderId,
                        DateofSale = _DateofSale,
                        PaymentMethod = _PaymentMethod,
                        ShippingCost = _ShippingCost,
                        Region = _Region
                    });
                    exitingOrdersId.Add(_OrderId);
                }
                if (!exitingProductsIds.Contains(_ProductId))
                {
                    _dbContext.Products.Add(new Product
                    {
                        ProductId = _ProductId,
                        ProductName = _ProductName,
                        Category = _Category
                    });
                    exitingProductsIds.Add(_ProductId);
                }

                _dbContext.OrderItems.Add(new OrderItem
                {
                    OrderId = _OrderId,
                    ProductId = _ProductId,
                    UnitPrice = _UnitPrice,
                    QuantitySold = _QuantitySold,
                    Discount = _Discount
                });

                count++;
                if (count >= batchcount)
                {
                    await _dbContext.SaveChangesAsync();
                    _dbContext.ChangeTracker.Clear();
                    count = 0;
                }
            }

                if(count >0)
                {
                    await _dbContext.SaveChangesAsync();
                }
        }
    }
}
