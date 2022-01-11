using MediatR;
using ProjectStore.Commands;
using ProjectStore.Models;
using ProjectStore.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,string>
    {
        private IProductService _service { get; }
        public AddProductHandler(IProductService service)
        {
            _service = service;
        }

        

     

        Task<string> IRequestHandler<AddProductCommand, string>.Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.ProductAdd(request.productDto, request.userId));
        }
    }
}
