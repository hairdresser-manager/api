using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<ServiceResult> VerifyEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return ServiceResult.Failure("User doesn't exists");

            if (await _userManager.IsEmailConfirmedAsync(user))
                return ServiceResult.Failure("Email already verified");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            
            if (!result.Succeeded)
                return ServiceResult.Failure(result.Errors.Select(x => x.Description));
            
            return ServiceResult.Success();
        }

        public async Task<ServiceResult> ChangePasswordAsync(string userId, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return ServiceResult.Failure("user doesn't exist");
            
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
                return ServiceResult.Failure(result.Errors.Select(x => x.Description));
            
            return ServiceResult.Success();
        }
        
        public async Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return null;

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
                return null;

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = await _userManager.GetRolesAsync(user);

            return userDto;
        }
    }
}