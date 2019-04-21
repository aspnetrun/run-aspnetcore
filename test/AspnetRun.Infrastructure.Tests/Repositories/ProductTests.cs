using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Tests.Builders;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AspnetRun.Infrastructure.Tests.Repositories
{
    public class ProductTests
    {
        private readonly AspnetRunContext _aspnetRunContext;
        private readonly ProductRepository _productRepository;
        private readonly ITestOutputHelper _output;
        private ProductBuilder ProductBuilder { get; } = new ProductBuilder();
        private CategoryBuilder CategoryBuilder { get; } = new CategoryBuilder();

        public ProductTests(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<AspnetRunContext>()
                .UseInMemoryDatabase(databaseName: "AspnetRun")
                .Options;
            _aspnetRunContext = new AspnetRunContext(dbOptions);
            _productRepository = new ProductRepository(_aspnetRunContext);
        }

        [Fact]
        public async Task Get_Existing_Product()
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

        [Fact]
        public async Task Get_Product_By_Name()
        {
            var existingProduct = ProductBuilder.WithDefaultValues();
            _aspnetRunContext.Products.Add(existingProduct);
            // GetProductByNameAsync spec required Category, because it is included Category entity so it should be exist
            var existingCategory = CategoryBuilder.WithDefaultValues();
            _aspnetRunContext.Categories.Add(existingCategory);

            _aspnetRunContext.SaveChanges();
            var productName = existingProduct.ProductName;
            _output.WriteLine($"ProductName: {productName}");
            
            var productListFromRepo = await _productRepository.GetProductByNameAsync(productName);
            Assert.Equal(ProductBuilder.TestProductName, productListFromRepo.ToList().First().ProductName);
        }

        [Fact]
        public async Task Get_Product_By_Category()
        {
            var existingProduct = ProductBuilder.WithDefaultValues();
            _aspnetRunContext.Products.Add(existingProduct);
            _aspnetRunContext.SaveChanges();
            var categoryId = existingProduct.CategoryId;
            _output.WriteLine($"CategoryId: {categoryId}");

            var productListFromRepo = await _productRepository.GetProductByCategoryAsync(categoryId);
            Assert.Equal(ProductBuilder.TestCategoryId, productListFromRepo.ToList().First().CategoryId);
        }
    }
}
