using MediatR;
using ProjectStore.Commands;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        public IProductService _service { get; }
        public UpdateProductHandler(IProductService service)
        {
            _service = service;
        }

        public Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            _service.ProductUpdate(request.ProductId, request.productDto, request.user);
            return Task.FromResult(Unit.Value);
        }
    }
}
