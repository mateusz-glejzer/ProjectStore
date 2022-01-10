using MediatR;
using ProjectStore.Models;

namespace ProjectStore.Commands
{
    public record AddProductCommand(ProductDto productDto, int userId) : IRequest<string>;
    
}
