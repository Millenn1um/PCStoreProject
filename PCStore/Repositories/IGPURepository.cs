using PCStore.Data;
using PCStore.Models;

namespace PCStore.Repositories
{
    public interface IGPURepository
    {
        IEnumerable<GPU> GetAllGPUs();
        GPU GetGPUById(int id);
        void AddGPU(GPU gpu);
        void UpdateGPU(GPU gpu);
        void DeleteGPU(int id);
    }

    public class GPURepository : IGPURepository
    {
        private readonly PcShopContext _context;

        public GPURepository(PcShopContext context)
        {
            _context = context;
        }

        public IEnumerable<GPU> GetAllGPUs() => _context.GPUs.ToList();

        public GPU GetGPUById(int id) => _context.GPUs.FirstOrDefault(g => g.Id == id);

        public void AddGPU(GPU gpu)
        {
            _context.GPUs.Add(gpu);
            _context.SaveChanges();
        }

        public void UpdateGPU(GPU gpu)
        {
            _context.GPUs.Update(gpu);
            _context.SaveChanges();
        }

        public void DeleteGPU(int id)
        {
            var gpu = GetGPUById(id);
            if (gpu != null)
            {
                _context.GPUs.Remove(gpu);
                _context.SaveChanges();
            }
        }
    }
}
