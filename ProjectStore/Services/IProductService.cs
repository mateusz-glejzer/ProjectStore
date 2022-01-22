using ProjectStore.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectStore.Services
{
    public interface IProductService
    {
        Task ProductAdd(ProductDto productDto, int userId);
        Task ProductDelete(int id, ClaimsPrincipal user);
        Task<List<ProductDto>> ProductGet();
        Task<ProductDto> ProductGet(int id);
        Task ProductUpdate(int ProductId, ProductDto productDto, ClaimsPrincipal user);
    }
}