﻿using Moq;
using PCStore.Models;
using PCStore.Services;

namespace PCStore.Tests.Services
{
    public class BusinessServiceTests
    {
        private readonly Mock<IProductService> _mockProductService;
        private readonly BusinessService _businessService;

        public BusinessServiceTests()
        {
            _mockProductService = new Mock<IProductService>();
            _businessService = new BusinessService(_mockProductService.Object);
        }

        [Fact]
        public void GetTotalInventoryValue_Returns_CorrectSum()
        {
            // Arrange
            var cpus = new List<CPU>
        {
            new CPU { Id = 1, Name = "Intel Core i7", Model = "14700K", Price = 300m, Cores = 8, ClockSpeed = 4.6f },
            new CPU { Id = 2, Name = "AMD Ryzen 5", Model = "7600X", Price = 200m, Cores = 6, ClockSpeed = 4.2f  }
        };

            var gpus = new List<GPU>
        {
            new GPU { Id = 1, Name = "NVIDIA", Model = "RTX 4060Ti", Price = 400m },
            new GPU { Id = 2, Name = "AMD Radeon", Model = "RX 7800 XT", Price = 500m }
        };

            _mockProductService.Setup(ps => ps.GetCPUs()).Returns(cpus);
            _mockProductService.Setup(ps => ps.GetGPUs()).Returns(gpus);

            // Act
            var totalValue = _businessService.GetTotalInventoryValue();

            // Assert
            Assert.Equal(1400m, totalValue);
        }

        [Fact]
        public void GetTotalProductsCount_Returns_CorrectCount()
        {
            // Arrange
            var cpus = new List<CPU> { new CPU { Id = 1 }, new CPU { Id = 2 } };
            var gpus = new List<GPU> { new GPU { Id = 1 }, new GPU { Id = 2 }, new GPU { Id = 3 } };

            _mockProductService.Setup(ps => ps.GetCPUs()).Returns(cpus);
            _mockProductService.Setup(ps => ps.GetGPUs()).Returns(gpus);

            // Act
            var productCount = _businessService.GetTotalProductsCount();

            // Assert
            Assert.Equal(5, productCount);
        }
    }
}