using AutoMapper;
using ProjectStore.Entities;
using ProjectStore.Models;

namespace ProjectStore

{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<UserDto, User>();

            //CreateMap<User, RegisterUserDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product > ();
        }
    }
}
