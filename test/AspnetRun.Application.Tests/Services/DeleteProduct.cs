using AspnetRun.Application.Services;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AspnetRun.Application.Tests.Services
{
    public class DeleteProduct
    {
        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IAsyncRepository<Category>> _mockCategoryRepository;        


        public DeleteProduct()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
        }

        //[Fact]
        //public async Task Should_GetOnce_WhenAddedTwoProduct()
        //{
        //    var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
        //    var product1 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
        //    var product2 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
            
        //    category.AddProduct(product1.Id, It.IsAny<string>());
        //    category.AddProduct(product2.Id, It.IsAny<string>());

        //    _mockCategoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);
        //    _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product1);
        //    _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product2);

        //    var productService = new ProductAppService(_mockProductRepository.Object);
        //    var productList = productService.GetProductList();

        //    _mockProductRepository.Verify(x => x.GetAllAsync(), Times.Once);            
        //}


    }
}
