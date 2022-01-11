using MediatR;
using ProjectStore.Commands;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand,Unit>
    {
        private IProductService _service { get; }
        public DeleteProductHandler(IProductService service)
        {
            _service = service;
        }

        Task<Unit> IRequestHandler<DeleteProductCommand, Unit>.Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _service.ProductDelete(request.id, request.user);
            return Task.FromResult(Unit.Value);
        }
    }
}
