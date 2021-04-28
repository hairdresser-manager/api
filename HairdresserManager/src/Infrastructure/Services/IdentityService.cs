using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;

        public IdentityService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Result> VerifyEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return Result.Failure("User doesn't exists");

            if (await _userManager.IsEmailConfirmedAsync(user))
                return Result.Failure("Email already verified");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            
            if (!result.Succeeded)
                return Result.Failure(result.Errors.Select(x => x.Description));
            
            return Result.Success();
        }

        public async Task<Result> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return Result.Failure("user doesn't exist");
            
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
                return Result.Failure(result.Errors.Select(x => x.Description));
            
            return Result.Success();
        }
    }
}