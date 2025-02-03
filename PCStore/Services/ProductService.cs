using PCStore.Models;
using PCStore.Repositories;

namespace PCStore.Services
{
    public class ProductService : IProductService
    {
        private readonly ICPURepository _cpuRepository;
        private readonly IGPURepository _gpuRepository;

        public ProductService(ICPURepository cpuRepository, IGPURepository gpuRepository)
        {
            _cpuRepository = cpuRepository;
            _gpuRepository = gpuRepository;
        }

        // Retrieve all CPUs
        public IEnumerable<CPU> GetCPUs() => _cpuRepository.GetAllCPUs();

        // Retrieve all GPUs
        public IEnumerable<GPU> GetGPUs() => _gpuRepository.GetAllGPUs();

        // Retrieve a product by its ID
        public object GetProductById(int id)
        {
            var cpu = _cpuRepository.GetCPUById(id);
            if (cpu != null) return cpu;

            var gpu = _gpuRepository.GetGPUById(id);
            return gpu;
        }

        // Add a CPU
        public void AddCPU(CPU cpu) => _cpuRepository.AddCPU(cpu);

        // Add a GPU
        public void AddGPU(GPU gpu) => _gpuRepository.AddGPU(gpu);

        // Delete a product by its ID
        public bool DeleteProduct(int id)
        {
            var cpu = _cpuRepository.GetCPUById(id);
            if (cpu != null)
            {
                _cpuRepository.DeleteCPU(id);
                return true;
            }

            var gpu = _gpuRepository.GetGPUById(id);
            if (gpu != null)
            {
                _gpuRepository.DeleteGPU(id);
                return true;
            }

            return false;
        }
    }
}
