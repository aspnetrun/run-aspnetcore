using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspnetRun.Web.Tests.Pages
{
    public class IndexPageTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public IndexPageTest(CustomWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task Index_Page_Test()
        {
            // Arrange & Act
            var response = await Client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Contains("AspnetRun", stringResponse);
        }        
    }
}
