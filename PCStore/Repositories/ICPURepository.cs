using PCStore.Data;
using PCStore.Models;

namespace PCStore.Repositories
{
    public interface ICPURepository
    {
        IEnumerable<CPU> GetAllCPUs();
        CPU GetCPUById(int id);
        void AddCPU(CPU cpu);
        void UpdateCPU(CPU cpu);
        void DeleteCPU(int id);
    }

    public class CPURepository : ICPURepository
    {
        private readonly PcShopContext _context;

        public CPURepository(PcShopContext context)
        {
            _context = context;
        }

        public IEnumerable<CPU> GetAllCPUs() => _context.CPUs.ToList();

        public CPU GetCPUById(int id) => _context.CPUs.FirstOrDefault(c => c.Id == id);

        public void AddCPU(CPU cpu)
        {
            _context.CPUs.Add(cpu);
            _context.SaveChanges();
        }

        public void UpdateCPU(CPU cpu)
        {
            _context.CPUs.Update(cpu);
            _context.SaveChanges();
        }

        public void DeleteCPU(int id)
        {
            var cpu = GetCPUById(id);
            if (cpu != null)
            {
                _context.CPUs.Remove(cpu);
                _context.SaveChanges();
            }
        }
    }
}
