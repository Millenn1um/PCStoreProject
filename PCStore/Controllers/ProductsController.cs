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

        // GET: api/products/cpus/{id}
        [HttpGet("cpus/{id}")]
        public IActionResult GetCPUById(int id)
        {
            var cpu = _productService.GetCPUById(id);
            if (cpu == null)
                return NotFound();
            return Ok(cpu);
        }

        // POST: api/products/cpus
        [HttpPost("cpus")]
        public IActionResult AddCPU([FromBody] CPU cpu)
        {
            if (cpu == null)
                return BadRequest();
            _productService.GetCPUs().ToList().Add(cpu);
            return CreatedAtAction(nameof(GetCPUById), new { id = cpu.Id }, cpu);
        }

        // DELETE: api/products/cpus/{id}
        [HttpDelete("cpus/{id}")]
        public IActionResult DeleteCPU(int id)
        {
            var cpu = _productService.GetCPUById(id);
            if (cpu == null)
                return NotFound();
            _productService.DeleteCPU(id);  // Uses the service method to delete CPU
            return NoContent();
        }

        // GET: api/products/gpus
        [HttpGet("gpus")]
        public IActionResult GetAllGPUs()
        {
            return Ok(_productService.GetGPUs());
        }

        // GET: api/products/gpus/{id}
        [HttpGet("gpus/{id}")]
        public IActionResult GetGPUById(int id)
        {
            var gpu = _productService.GetGPUById(id);
            if (gpu == null)
                return NotFound();
            return Ok(gpu);
        }

        // POST: api/products/gpus
        [HttpPost("gpus")]
        public IActionResult AddGPU([FromBody] GPU gpu)
        {
            if (gpu == null)
                return BadRequest();
            _productService.GetGPUs().ToList().Add(gpu);
            return CreatedAtAction(nameof(GetGPUById), new { id = gpu.Id }, gpu);
        }

        // DELETE: api/products/gpus/{id}
        [HttpDelete("gpus/{id}")]
        public IActionResult DeleteGPU(int id)
        {
            var gpu = _productService.GetGPUById(id);
            if (gpu == null)
                return NotFound();
            _productService.DeleteGPU(id);  // Uses the service method to delete GPU
            return NoContent();
        }
    }
}
