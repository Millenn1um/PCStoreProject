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

        // Retrieve a CPU by its ID
        public CPU GetCPUById(int id) => _cpuRepository.GetCPUById(id);

        // Retrieve a GPU by its ID
        public GPU GetGPUById(int id) => _gpuRepository.GetGPUById(id);

        // Delete a CPU by its ID
        public void DeleteCPU(int id)
        {
            var cpu = _cpuRepository.GetCPUById(id);
            if (cpu != null)
            {
                _cpuRepository.DeleteCPU(id);  // Call the repository's Delete method
            }
        }

        // Delete a GPU by its ID
        public void DeleteGPU(int id)
        {
            var gpu = _gpuRepository.GetGPUById(id);
            if (gpu != null)
            {
                _gpuRepository.DeleteGPU(id);  // Call the repository's Delete method
            }
        }
    }
}
