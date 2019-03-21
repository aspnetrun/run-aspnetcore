using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspnetRun.Web.Tests.Pages
{
    public class IndexPageOnGet : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public IndexPageOnGet(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsIndexPageWithProductListing()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("product", stringResponse);
        }
    }
}
