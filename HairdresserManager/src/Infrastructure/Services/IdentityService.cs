using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using AutoMapper;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<User> userManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
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
        
        public async Task<UserDto> GetUserDtoByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return null;

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
                return null;

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Role = _userService.GetUserRoleById(user.Id.ToString());

            return userDto;
        }
    }
}