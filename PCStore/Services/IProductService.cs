using PCStore.Models;

namespace PCStore.Services
{
    public interface IProductService
    {
        IEnumerable<CPU> GetCPUs();
        IEnumerable<GPU> GetGPUs();
        CPU GetCPUById(int id);
        GPU GetGPUById(int id);
    }
}
