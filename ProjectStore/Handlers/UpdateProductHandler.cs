using MediatR;
using ProjectStore.Commands;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, string>
    {
        public IProductService _service { get; }
        public UpdateProductHandler(IProductService service)
        {
            _service = service;
        }

        public Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.ProductUpdate(request.ProductId,request.productDto,request.user));
        }
    }
}
