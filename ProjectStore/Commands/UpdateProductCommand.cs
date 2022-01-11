using MediatR;
using ProjectStore.Models;
using System.Security.Claims;

namespace ProjectStore.Commands
{
    public record UpdateProductCommand(int ProductId, ProductDto productDto, ClaimsPrincipal user):IRequest;
    
    
}
