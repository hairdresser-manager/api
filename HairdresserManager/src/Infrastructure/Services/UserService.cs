using System;
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
            return user == null ? null : UserToUserDto(user);
        }

        public async Task<UserDto> GetUserDtoByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user == null ? null : UserToUserDto(user);
        }

        public async Task<(Result, Guid, string)> CreateUserAsync(UserDto userDto, string password)
        {
            var newUser = _mapper.Map<User>(userDto);
            
            var createdUser = await _userManager.CreateAsync(newUser, password);

            if (!createdUser.Succeeded)
                return (Result.Failure(createdUser.Errors.Select(x => x.Description)), Guid.Empty, null);

            var verifyToken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            return (Result.Success(), newUser.Id, verifyToken);
        }

        public async Task<Result> UpdateUserDataAsync(string userId, UserDto userDto)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return Result.Failure("User doesn't exist");

            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.MobilePhone;

            var result = await _userManager.UpdateAsync(user);
            return !result.Succeeded ? Result.Failure(result.Errors.Select(x => x.Description)) : Result.Success();
        }

        public string GetUserRoleById(string userId)
        {
            //TODO: not implemented yet
            return "client";
        }

        private UserDto UserToUserDto(User user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Role = GetUserRoleById(user.Id.ToString());
            return userDto;
        }
    }
}