namespace PCStore.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly IProductService _productService;

        public BusinessService(IProductService productService)
        {
            _productService = productService;
        }

        public decimal GetTotalInventoryValue()
        {
            var cpuValue = _productService.GetCPUs().Sum(cpu => cpu.Price);
            var gpuValue = _productService.GetGPUs().Sum(gpu => gpu.Price);
            return cpuValue + gpuValue;
        }

        public int GetTotalProductsCount()
        {
            var cpuCount = _productService.GetCPUs().Count();
            var gpuCount = _productService.GetGPUs().Count();
            return cpuCount + gpuCount;
        }
    }
}
