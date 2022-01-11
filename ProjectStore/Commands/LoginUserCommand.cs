using MediatR;
using ProjectStore.Controllers;

namespace ProjectStore.Commands
{
    public record LoginUserCommand(LoginDto dto) :IRequest<string>;
    
}
