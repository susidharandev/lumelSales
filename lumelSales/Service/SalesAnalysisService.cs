using lumelSales.Data;
using Microsoft.EntityFrameworkCore;

namespace lumelSales.Service
{
    public class SalesAnalysisService
    {
        public readonly AppDbContext _appDbContext;
        public SalesAnalysisService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<decimal> TotalRevenue(DateTime from, DateTime to)
        {
            return await _appDbContext.OrderItems
                .Where(o => o.Order.DateofSale >= from && o.Order.DateofSale <= to)
                .SumAsync(o => o.UnitPrice * o.QuantitySold * (1 - o.Discount));
        }
        public async Task<List<object>> TotalRevenueByProduct(DateTime from, DateTime to)
        {
            return await _appDbContext.OrderItems
                                .Where(o => o.Order.DateofSale >= from && o.Order.DateofSale <= to)
                                .GroupBy(o => o.Product.ProductName)
                                .Select(g => new
                                {
                                    Product = g.Key,
                                    Revenue = g.Sum(x => x.UnitPrice * x.QuantitySold * (1 - x.Discount))
                                }).ToListAsync<object>();

        }
        public async Task<List<object>> TotalRevenueByCategory(DateTime from, DateTime to)
        {
            return await _appDbContext.OrderItems
                               .Where(o => o.Order.DateofSale >= from && o.Order.DateofSale <= to)
                               .GroupBy(o => o.Product.Category)
                               .Select(g => new
                               {
                                   Product = g.Key,
                                   Revenue = g.Sum(x => x.UnitPrice * x.QuantitySold * (1 - x.Discount))
                               }).ToListAsync<object>();
        }
        public async Task<List<object>> TotalRevenueByRegion(DateTime from, DateTime to)
        {
            return await _appDbContext.OrderItems
                               .Where(o => o.Order.DateofSale >= from && o.Order.DateofSale <= to)
                               .GroupBy(o => o.Order.Region)
                               .Select(g => new
                               {
                                   Product = g.Key,
                                   Revenue = g.Sum(x => x.UnitPrice * x.QuantitySold * (1 - x.Discount))
                               }).ToListAsync<object>();
        }
    }
}
