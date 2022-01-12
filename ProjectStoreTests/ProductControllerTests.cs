using System;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using ProjectStore;
using System.Net.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectStore.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectStoreTests
{
    public class ProductControllerTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        public ProductControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory
                .WithWebHostBuilder(builder => {

                    builder.ConfigureServices(services =>
                    {
                        var dbcontextOptions= services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<StoreDbContext>));
                        services.Remove(dbcontextOptions);
                        services.AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("StoreDb"));
                    });
                    })
                .CreateClient();
        }
        
        [Fact]
        public void GetAll_()
        {

        }
    }
}
