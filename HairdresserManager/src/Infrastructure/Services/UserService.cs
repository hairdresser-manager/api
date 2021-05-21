using System;
using System.Collections.Generic;
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
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserDto> GetUserDtoByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user == null ? null : await UserToUserDtoAsync(user);
        }

        public async Task<UserDto> GetUserDtoByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user == null ? null : await UserToUserDtoAsync(user);
        }

        public async Task<(ServiceResult, Guid, string)> CreateUserAsync(UserDto userDto, string password)
        {
            var newUser = _mapper.Map<User>(userDto);
            
            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
                return (ServiceResult.Failure(createdUser.Errors.Select(x => x.Description)), Guid.Empty, null);

            var verifyToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            await _userManager.AddToRoleAsync(newUser, ApplicationCore.Entities.Role.User);
            
            return (ServiceResult.Success(), newUser.Id, verifyToken);
        }

        public async Task<ServiceResult> UpdateUserDataAsync(string userId, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return ServiceResult.Failure("User doesn't exist");

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.MobilePhone;

            var result = await _userManager.UpdateAsync(user);
            return !result.Succeeded ? ServiceResult.Failure(result.Errors.Select(x => x.Description)) : ServiceResult.Success();
        }
        
        public async Task<IEnumerable<string>> GetUserRolesById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.GetRolesAsync(user);
        }

        public async Task RemoveFromRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, role);
        }

        public async Task AddToRoleAsync(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, role);
        }

        private async Task<UserDto> UserToUserDtoAsync(User user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Roles = await _userManager.GetRolesAsync(user);
            return userDto;
        }
    }
}