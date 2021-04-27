using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var userDto = new UserDTO
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobilePhone = user.PhoneNumber,
                Role = "client"
            };

            return userDto;
        }

        public async Task<(Result, Guid, string)> CreateUserAsync(RegisterRequest userDto)
        {
            var newUser = new User
            {
                Email = userDto.Email,
                UserName = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PhoneNumber = userDto.MobilePhone
            };

            var createdUser = await _userManager.CreateAsync(newUser, userDto.Password);

            if (!createdUser.Succeeded)
            {
                return (Result.Failure(createdUser.Errors.Select(x => x.Description)), Guid.Empty, null);
            }

            var verifyToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

            return (Result.Success(), newUser.Id, verifyToken);
        }

        public async Task<Result> VerifyEmailAsync(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
                return Result.Failure("User doesn't exists");

            if (await _userManager.IsEmailConfirmedAsync(user))
                return Result.Failure("Email already verified");

            var result = await _userManager.ConfirmEmailAsync(user, token);

            return result.Succeeded ? Result.Success() : Result.Failure(result.Errors.Select(x => x.Description));
        }
    }
}