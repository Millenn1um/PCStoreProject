using Microsoft.AspNetCore.Mvc;
using PCStore.Services;

namespace PCStore.Controllers
{
    [Route("api/business")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        // GET: api/business/total-inventory-value
        [HttpGet("total-inventory-value")]
        public IActionResult GetTotalInventoryValue()
        {
            var totalInventoryValue = _businessService.GetTotalInventoryValue();
            return Ok(new { TotalInventoryValue = totalInventoryValue });
        }

        // GET: api/business/total-products-count
        [HttpGet("total-products-count")]
        public IActionResult GetTotalProductsCount()
        {
            var totalProductsCount = _businessService.GetTotalProductsCount();
            return Ok(new { TotalProductsCount = totalProductsCount });
        }
    }
}
