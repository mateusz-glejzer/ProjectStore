using ProjectStore.Controllers;
using ProjectStore.Models;

namespace ProjectStore.Services
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto dto);
        public string GenerateJwt(LoginDto dto);
    }
}