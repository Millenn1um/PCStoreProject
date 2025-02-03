using Microsoft.AspNetCore.Mvc;
using PCStore.Models;
using PCStore.Services;

namespace PCStore.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products/cpus
        [HttpGet("cpus")]
        public IActionResult GetAllCPUs()
        {
            return Ok(_productService.GetCPUs());
        }

        // GET: api/products/gpus
        [HttpGet("gpus")]
        public IActionResult GetAllGPUs()
        {
            return Ok(_productService.GetGPUs());
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/products/cpus
        [HttpPost("cpus")]
        public IActionResult AddCPU([FromBody] CPU cpu)
        {
            if (cpu == null)
                return BadRequest();
            _productService.AddCPU(cpu);
            return CreatedAtAction(nameof(GetProductById), new { id = cpu.Id }, cpu);
        }

        // POST: api/products/gpus
        [HttpPost("gpus")]
        public IActionResult AddGPU([FromBody] GPU gpu)
        {
            if (gpu == null)
                return BadRequest();
            _productService.AddGPU(gpu);
            return CreatedAtAction(nameof(GetProductById), new { id = gpu.Id }, gpu);
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bool deleted = _productService.DeleteProduct(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}