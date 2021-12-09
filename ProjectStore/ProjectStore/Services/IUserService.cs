using ProjectStore.Models;

namespace ProjectStore.Services
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto dto);
    }
}