using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ProjectStore.Entities;

namespace ProjectStore.Services
{
    public class BasketService
    {
        private readonly StoreDbContext context;
        private readonly IMapper mapper;
        private readonly IAuthorizationService authorizationService;
        public BasketService(StoreDbContext context, IMapper mapper, IAuthorizationService authorizationService)
        {
            this.context = context;
            this.mapper = mapper;
            this.authorizationService = authorizationService;
        }
    }
}
