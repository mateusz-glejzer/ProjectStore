using MediatR;
using ProjectStore.Models;

namespace ProjectStore.Commands
{
    public record RegisterUserCommand(RegisterUserDto dto) :IRequest;
    
    
}
