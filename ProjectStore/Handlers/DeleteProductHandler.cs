using MediatR;
using ProjectStore.Commands;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand,string>
    {
        private IProductService _service { get; }
        public DeleteProductHandler(IProductService service)
        {
            _service = service;
        }

        Task<string> IRequestHandler<DeleteProductCommand, string>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.ProductDelete(request.id, request.user));
        }
    }
}
