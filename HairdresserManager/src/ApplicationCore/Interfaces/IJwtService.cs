using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IJwtService
    {
        string GenerateAccessToken(UserDto userDto);
    }
}