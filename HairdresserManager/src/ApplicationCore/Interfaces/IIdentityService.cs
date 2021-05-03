using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> VerifyEmailAsync(string email, string token);
        Task<Result> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password); 
    }
}