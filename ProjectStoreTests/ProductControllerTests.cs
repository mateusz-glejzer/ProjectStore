﻿using FluentAssertions;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ProjectStore;
using ProjectStore.Entities;
using ProjectStore.Models;
using ProjectStoreBlazorTests;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectStoreTests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private HttpClient _client;
        WebApplicationFactory<Startup> _factory;
        public ProductControllerTests(WebApplicationFactory<Startup> factory)
        {


            _factory = factory
                .WithWebHostBuilder(builder =>
                {

                    builder.ConfigureServices(services =>
                    {
                        var dbcontextOptions = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<StoreDbContext>));
                        services.Remove(dbcontextOptions);
                        services.AddSingleton<IPolicyEvaluator, FakePolicyEvaluator>();
                        services.AddMvc(option => option.Filters.Add(new FakeUserFilter()));
                        services.AddEntityFrameworkInMemoryDatabase().AddDbContext<StoreDbContext>(options => options.UseInMemoryDatabase("StoreDb"));
                    });
                });
            _client = _factory.CreateClient();
                
        }
        private void Seed(Product product) 
        {
            var scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopeFactory.CreateScope();
            var _dbContext = scope.ServiceProvider.GetService<StoreDbContext>();
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task CreateProduct_WithValidModel_ReturnOkStatus()
        {
            //arange
            var model = new ProductDto()
            {
                Name = "bacardi",
                Description = "w Klubie ze szklanki",
                IsAvailable = true,
                Price = 420,

            };
            var json = JsonConvert.SerializeObject(model);
            var httpContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            //act
            var response = await _client.PostAsync("Product/Add", httpContent);
            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            

        }
        [Fact]
        public async Task DeleteProduct_ForNonExistingProduct_ReturnsNotFound()
        {   //arange
            var productId = 997;
            //act
            var response = await _client.DeleteAsync($"Product/Delete/{productId}");
            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
           
        }
        [Fact]
        public async Task Delete_ForValidUser_ReturnsNoContent() 
        {
            //arrange
           
            var product = new Product
            {
                CreatedByUserId = 1,
                Name = "Test"
            };
            //seed
            Seed(product);
            //act
            var response = await _client.DeleteAsync($"Product/Delete/{product.CreatedByUserId}");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);


        }


        [Fact]
        public async void GetElementById_WithValidIdParameter_ReturnOkResult()
        {
            //arange
            var product = new Product()
            {
                Id = 1,
                Name = "testproduct1",
                Description = "producttotest",
                IsAvailable = true,
                Price = 420,

            };
            //seed

            Seed(product);
            //act
            var response = await _client.GetAsync($"Product/Get/{1}");
           

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}