using MediatR;
using ProjectStore.Models;
using ProjectStore.Queries;
using ProjectStore.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace ProjectStore.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private IProductService _service { get; }

        public GetProductByIdHandler(IProductService service)
        {
            _service = service;
        }

    
        public  Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.ProductGetById());
        }
    }
}
