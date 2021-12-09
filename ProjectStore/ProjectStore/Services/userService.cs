using AutoMapper;
using ProjectStore.Entities;
using ProjectStore.Models;

namespace ProjectStore.Services
{
    public class UserService : IUserService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;

        public UserService(StoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User();
            newUser = _mapper.Map<User>(dto);

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

    }
}
