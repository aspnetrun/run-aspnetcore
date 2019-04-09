using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Tests.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AspnetRun.Infrastructure.Tests.Repositories
{
    public class ProductGetById
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly ProductRepository _productRepository;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();

        private readonly ITestOutputHelper _output;
        public ProductGetById(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<AspnetRunContext>()
                .UseInMemoryDatabase(databaseName: "TestProduct")
                .Options;
            _aspnetRunContext = new AspnetRunContext(dbOptions);
            _productRepository = new ProductRepository(_aspnetRunContext);
        }

        [Fact]
        public async Task GetsExistingProduct()
        {
            var existingProduct = ProductBuilder.WithDefaultValues();
            _aspnetRunContext.Products.Add(existingProduct);
            _aspnetRunContext.SaveChanges();
            var productId = existingProduct.Id;
            _output.WriteLine($"ProductId: {productId}");

            var productFromRepo = await _productRepository.GetByIdAsync(productId);
            Assert.Equal(ProductBuilder.TestProductId, productFromRepo.Id);
            Assert.Equal(ProductBuilder.TestCategoryId, productFromRepo.CategoryId);
        }

    }
}
