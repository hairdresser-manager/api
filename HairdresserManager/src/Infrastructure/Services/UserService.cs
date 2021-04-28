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

        public async Task<UserDTO> GetUserDtoByCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user is not {EmailConfirmed: true})
                return null;

            var hasValidPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!hasValidPassword)
                return null;

            var userDto = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobilePhone = user.PhoneNumber,
                Role = GetUserRoleById(user.Id)
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

        public async Task<UserDTO> GetUserDtoByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            var userDto = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                MobilePhone = user.PhoneNumber,
                Role = GetUserRoleById(user.Id)
            };

            return userDto;
        }
        
        public async Task<Result> UpdateUserDataAsync(string userId, UserDTO userDto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null)
                return Result.Failure("User doesn't exist");

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.MobilePhone;
            
            var result = await _userManager.UpdateAsync(user);
            
            if (!result.Succeeded)
                return Result.Failure(result.Errors.Select(x => x.Description));
            
            return Result.Success();
        }

        private string GetUserRoleById(Guid userId)
        {
            //TODO: not implemented yet
            return "client";
        }
    }
}