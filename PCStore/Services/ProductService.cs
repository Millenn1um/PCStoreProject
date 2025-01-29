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

        public IEnumerable<CPU> GetCPUs() => _cpuRepository.GetAllCPUs();

        public IEnumerable<GPU> GetGPUs() => _gpuRepository.GetAllGPUs();

        public CPU GetCPUById(int id) => _cpuRepository.GetCPUById(id);

        public GPU GetGPUById(int id) => _gpuRepository.GetGPUById(id);
    }
}
