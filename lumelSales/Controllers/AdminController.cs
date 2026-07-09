using lumelSales.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lumelSales.Controllers
{
    [Route("api/csv")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly CsvImportService _csvImportService;
        public AdminController(CsvImportService csvImportService) 
        { 
            _csvImportService = csvImportService;
        }
        [Route("import")]
        public async Task<ActionResult> Import()
        
        {
            await _csvImportService.ImportCsv();
            return Ok("Import Success");
        }
    }
}
