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

        // PUT: api/products/cpus/{id}
        [HttpPut("cpus/{id}")]
        public IActionResult UpdateCPU(int id, [FromBody] CPU cpu)
        {
            if (cpu == null || cpu.Id != id)
                return BadRequest();
            var existingCPU = _productService.GetCPUById(id);
            if (existingCPU == null)
                return NotFound();
            existingCPU.Name = cpu.Name;
            existingCPU.Brand = cpu.Brand;
            existingCPU.Price = cpu.Price;
            existingCPU.Cores = cpu.Cores;
            existingCPU.ClockSpeed = cpu.ClockSpeed;
            return NoContent();
        }

        // DELETE: api/products/cpus/{id}
        [HttpDelete("cpus/{id}")]
        public IActionResult DeleteCPU(int id)
        {
            var cpu = _productService.GetCPUById(id);
            if (cpu == null)
                return NotFound();
            _productService.GetCPUs().ToList().Remove(cpu);
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

        // PUT: api/products/gpus/{id}
        [HttpPut("gpus/{id}")]
        public IActionResult UpdateGPU(int id, [FromBody] GPU gpu)
        {
            if (gpu == null || gpu.Id != id)
                return BadRequest();
            var existingGPU = _productService.GetGPUById(id);
            if (existingGPU == null)
                return NotFound();
            existingGPU.Name = gpu.Name;
            existingGPU.Brand = gpu.Brand;
            existingGPU.Price = gpu.Price;
            existingGPU.Memory = gpu.Memory;
            return NoContent();
        }

        // DELETE: api/products/gpus/{id}
        [HttpDelete("gpus/{id}")]
        public IActionResult DeleteGPU(int id)
        {
            var gpu = _productService.GetGPUById(id);
            if (gpu == null)
                return NotFound();
            _productService.GetGPUs().ToList().Remove(gpu);
            return NoContent();
        }
    }
}
