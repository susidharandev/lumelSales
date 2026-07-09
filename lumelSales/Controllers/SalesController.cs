using lumelSales.Data;
using lumelSales.Service;
using Microsoft.AspNetCore.Mvc;

namespace lumelSales.Controllers
{
    [Route("api/sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesAnalysisService _salesAnalysisService;
        public SalesController(SalesAnalysisService salesAnalysisService)
        {
            _salesAnalysisService = salesAnalysisService;
        }
        [Route("total")]
        public async Task<ActionResult> TotalRevenue([FromQuery] DateTime from , [FromQuery] DateTime to)
        {
            var result = await _salesAnalysisService.TotalRevenue(from, to);

            return Ok(result);
        }
        [Route("product")]
        public async Task<ActionResult> TotalRevenueByProduct([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var result = await _salesAnalysisService.TotalRevenueByProduct(from, to);

            return Ok(result);
        }
        [Route("category")]
        public async Task<ActionResult> TotalRevenueByCategory([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var result = await _salesAnalysisService.TotalRevenueByCategory(from, to);

            return Ok(result);
        }
        [Route("region")]
        public async Task<ActionResult> TotalRevenueByRegion([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var result = await _salesAnalysisService.TotalRevenueByRegion(from, to);

            return Ok(result);
        }
    }
}
