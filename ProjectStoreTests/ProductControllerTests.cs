using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ProjectStore;
using System.Net.Http;

namespace ProjectStoreTests
{
    public class ProductControllerTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        public ProductControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
        [Fact]
        public void GetAll_()
        {

        }
    }
}
