using MediatR;
using ProjectStore.Models;

namespace ProjectStore.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<ProductDto>;
    
    
}
