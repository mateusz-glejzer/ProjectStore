using MediatR;
using ProjectStore.Commands;
using ProjectStore.Models;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Unit>
    {
        private IProductService _service { get; }
        public AddProductHandler(IProductService service)
        {
            _service = service;
        }

        

     


        Task<Unit> IRequestHandler<AddProductCommand, Unit>.Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            _service.ProductAdd(request.productDto, request.userId);
            return Task.FromResult(Unit.Value);
        }
    }
}
