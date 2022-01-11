using ProjectStore.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectStore.Services
{
    public interface IProductService
    {
        void ProductAdd(ProductDto productDto, int userId);
        string ProductDelete(int id, ClaimsPrincipal user);
        List<ProductDto> ProductGet();
        ProductDto ProductGetById();
        string ProductUpdate(int ProductId, ProductDto productDto, ClaimsPrincipal user);
    }
}