using ProjectStore.Models;
using System.Collections.Generic;

namespace ProjectStore.Services
{
    public interface IProductService
    {
        string ProductAdd(ProductDto product);
        string ProductDelete(int id);
        string ProductUpdate(ProductDto product);
        List<ProductDto> ProductGet();
    }
}