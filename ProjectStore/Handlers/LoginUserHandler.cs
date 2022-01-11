using MediatR;
using ProjectStore.Commands;
using ProjectStore.Controllers;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class LoginUserHandler : IRequestHandler<LoginUserCommand, string>
    {
        public IUserService _service { get; }
        public LoginUserHandler(IUserService service)
        {
            _service = service;
        }



        public Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.GenerateJwt(request.dto));
        }
    }
}
