using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using PCStore.Services;

namespace Tests
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
    }
}
