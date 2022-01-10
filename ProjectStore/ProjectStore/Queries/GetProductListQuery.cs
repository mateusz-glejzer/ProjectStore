using MediatR;
using ProjectStore.Entities;
using ProjectStore.Models;
using System.Collections.Generic;

namespace ProjectStore.Queries
{
    public record GetProductListQuery() :IRequest<List<ProductDto>>;
    
   
    
}
