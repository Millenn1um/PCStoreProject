using Xunit;
using Moq;
using PCStore.Models;
using PCStore.Repositories;
using PCStore.Services;
using System.Collections.Generic;

namespace PCStore.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<ICPURepository> _mockCpuRepository;
        private readonly Mock<IGPURepository> _mockGpuRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockCpuRepository = new Mock<ICPURepository>();
            _mockGpuRepository = new Mock<IGPURepository>();
            _productService = new ProductService(_mockCpuRepository.Object, _mockGpuRepository.Object);
        }

        [Fact]
        public void GetCPUs_ReturnsAllCPUs()
        {
            var cpus = new List<CPU> { new CPU { Id = 1, Name = "Intel Core", Model = "i9 14900K", Price = 900, Cores = 24, ClockSpeed = 4.8f }, new CPU { Id = 2, Name = "AMD Ryzen", Model = "7 9700X", Price = 600, Cores = 16, ClockSpeed = 5.2f }};
            _mockCpuRepository.Setup(repo => repo.GetAllCPUs()).Returns(cpus);

            var result = _productService.GetCPUs();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetGPUs_ReturnsAllGPUs()
        {
            var gpus = new List<GPU> { new GPU { Id = 1, Name = "NVIDIA", Model = "RTX 3080", Price = 800, Memory = 10 }, new GPU { Id = 2, Name = "AMD", Model = "RX 6800", Price = 700, Memory = 16 } };
            _mockGpuRepository.Setup(repo => repo.GetAllGPUs()).Returns(gpus);

            var result = _productService.GetGPUs();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetProductById_ReturnsCPU_WhenIdMatchesCPU()
        {
            var cpu = new CPU { Id = 1, Name = "Intel Core", Model = "i9 14900K", Price = 900, Cores = 24, ClockSpeed = 4.8f };
            _mockCpuRepository.Setup(repo => repo.GetCPUById(1)).Returns(cpu);

            var result = _productService.GetProductById(1);

            Assert.Equal(cpu, result);
        }

        [Fact]
        public void GetProductById_ReturnsGPU_WhenIdMatchesGPU()
        {
            var gpu = new GPU { Id = 2, Name = "NVIDIA", Model = "RTX 3080", Price = 800, Memory = 10 };
            _mockGpuRepository.Setup(repo => repo.GetGPUById(2)).Returns(gpu);

            var result = _productService.GetProductById(2);

            Assert.Equal(gpu, result);
        }

        [Fact]
        public void GetProductById_ReturnsNull_WhenIdNotFound()
        {
            _mockCpuRepository.Setup(repo => repo.GetCPUById(It.IsAny<int>())).Returns(() => null);
            _mockGpuRepository.Setup(repo => repo.GetGPUById(It.IsAny<int>())).Returns(() => null);

            var result = _productService.GetProductById(3);

            Assert.Null(result);
        }

        [Fact]
        public void DeleteProduct_ReturnsTrue_WhenCPUDeleted()
        {
            _mockCpuRepository.Setup(repo => repo.GetCPUById(1)).Returns(new CPU { Id = 1, Name = "Intel Core", Model = "i9 14900K", Price = 900, Cores = 24, ClockSpeed = 4.8f });
            _mockCpuRepository.Setup(repo => repo.DeleteCPU(1));

            var result = _productService.DeleteProduct(1);

            Assert.True(result);
        }

        [Fact]
        public void DeleteProduct_ReturnsTrue_WhenGPUDeleted()
        {
            _mockGpuRepository.Setup(repo => repo.GetGPUById(2)).Returns(new GPU { Id = 2, Name = "NVIDIA", Model = "RTX 3080", Price = 800, Memory = 10 });
            _mockGpuRepository.Setup(repo => repo.DeleteGPU(2));

            var result = _productService.DeleteProduct(2);

            Assert.True(result);
        }

        [Fact]
        public void DeleteProduct_ReturnsFalse_WhenProductNotFound()
        {
            _mockCpuRepository.Setup(repo => repo.GetCPUById(It.IsAny<int>())).Returns(() => null);
            _mockGpuRepository.Setup(repo => repo.GetGPUById(It.IsAny<int>())).Returns(() => null);

            var result = _productService.DeleteProduct(3);

            Assert.False(result);
        }
    }
}
