using ProjectStore.Models;
using System.Collections.Generic;
using System.Security.Claims;

namespace ProjectStore.Services
{
    public interface IProductService
    {
        string ProductAdd(ProductDto productDto, int userId);
        string ProductDelete(int id, ClaimsPrincipal user);
        List<ProductDto> ProductGet();
        string ProductUpdate(int ProductId, ProductDto productDto, ClaimsPrincipal user);
    }
}