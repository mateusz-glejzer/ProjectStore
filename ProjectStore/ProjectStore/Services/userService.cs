using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProjectStore.Entities;
using ProjectStore.Models;

namespace ProjectStore.Services
{
    public class UserService : IUserService
    {
        private readonly StoreDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(StoreDbContext context, IMapper mapper,IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User();
            newUser = _mapper.Map<User>(dto);
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

    }
}
