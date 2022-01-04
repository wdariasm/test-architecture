using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TicketManagement.Api;
using TicketManagement.API.IntegrationTests.Base;
using TicketManagement.Application.Features.Categories.Queries.GetCategoriesList;
using Xunit;

namespace TicketManagement.API.IntegrationTests.Controllers
{
    public class CategoryControllerTests: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;
        public CategoryControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task ReturnsSuccessResult()
        {
            var client = _factory.GetAnonymousClient();

            var response = await client.GetAsync("/api/category");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<List<CategoryListVm>>(responseString);

            Assert.IsType<List<CategoryListVm>>(result);
            Assert.NotEmpty(result);
        }
    }
}
