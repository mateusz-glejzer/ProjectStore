using AutoMapper;
using ProjectStore.Entities;
using ProjectStore.Models;

namespace ProjectStore

{
    public class StoreMappingProfile : Profile
    {
        public StoreMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, RegisterUserDto>().ForMember(m=>m.Password,c=>c.MapFrom(d=>d.PasswordHash));

        }
    }
}
