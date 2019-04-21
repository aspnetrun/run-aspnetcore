using AspnetRun.Application.Exceptions;
using AspnetRun.Application.Services;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace AspnetRun.Application.Tests.Services
{
    public class ProductTests
    {
        // NOTE : This layer we are not loaded database objects, test functionality of application layer

        private Mock<IProductRepository> _mockProductRepository;
        private Mock<IAsyncRepository<Category>> _mockCategoryRepository;
        private Mock<IAppLogger<ProductAppService>> _mockAppLogger;

        public ProductTests()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            _mockAppLogger = new Mock<IAppLogger<ProductAppService>>();
        }      

        [Fact]
        public async Task Get_Product_List()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product1 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
            var product2 = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());

            category.AddProduct(product1.Id, It.IsAny<string>());
            category.AddProduct(product2.Id, It.IsAny<string>());

            _mockCategoryRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(category);
            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product1);
            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product2);

            var productService = new ProductAppService(_mockProductRepository.Object, _mockAppLogger.Object);
            var productList = await productService.GetProductList();

            _mockProductRepository.Verify(x => x.GetProductListAsync(), Times.Once);
        }

        [Fact]
        public async Task Create_New_Product()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());
            Product nullProduct = null; // we gave null product in order to create new one, if you give real product it returns already existing error

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(nullProduct);
            _mockProductRepository.Setup(x => x.AddAsync(product)).ReturnsAsync(product);            

            var productService = new ProductAppService(_mockProductRepository.Object, _mockAppLogger.Object);
            var createdProductDto = await productService.Create(new Dtos.ProductDto { Id = product.Id, CategoryId = product.CategoryId, ProductName = product.ProductName });

            _mockProductRepository.Verify(x => x.GetByIdAsync(It.IsAny<int>()), Times.Once);
            _mockProductRepository.Verify(x => x.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task Create_New_Product_Validate_If_Exist()
        {
            var category = Category.Create(It.IsAny<int>(), It.IsAny<string>());
            var product = Product.Create(It.IsAny<int>(), category.Id, It.IsAny<string>());            

            _mockProductRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            _mockProductRepository.Setup(x => x.AddAsync(product)).ReturnsAsync(product);

            var productService = new ProductAppService(_mockProductRepository.Object, _mockAppLogger.Object);

            await Assert.ThrowsAsync<ApplicationException>(async () =>
                await productService.Create(new Dtos.ProductDto { Id = product.Id, CategoryId = product.CategoryId, ProductName = product.ProductName }));
        }
    }
}
