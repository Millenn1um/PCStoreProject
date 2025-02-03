using PCStore.Models;

namespace PCStore.Services
{
    public interface IProductService
    {
        IEnumerable<CPU> GetCPUs();
        IEnumerable<GPU> GetGPUs();
        object GetProductById(int id);
        void AddCPU(CPU cpu);
        void AddGPU(GPU gpu);
        bool DeleteProduct(int id);
    }
}