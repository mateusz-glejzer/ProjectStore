using MediatR;
using ProjectStore.Entities;
using ProjectStore.Models;
using ProjectStore.Queries;
using ProjectStore.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectStore.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private IProductService _service { get; }

        public GetProductListHandler(IProductService service)
        {
            _service = service;
        }

        
        public Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_service.ProductGet());
        }
    }
}
