using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IIdentityService
    {
        Task<ServiceResult> VerifyEmailAsync(string email, string token);
        Task<ServiceResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword);
        Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password); 
    }
}