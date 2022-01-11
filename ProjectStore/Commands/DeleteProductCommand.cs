using MediatR;
using System.Security.Claims;

namespace ProjectStore.Commands
{
    public record DeleteProductCommand(int id, ClaimsPrincipal user) :IRequest;
    
    
}
