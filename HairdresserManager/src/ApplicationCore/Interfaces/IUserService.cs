using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserDtoByEmailAsync(string email);
        Task<UserDto> GetUserDtoByIdAsync(string userId);
        Task<Result> UpdateUserDataAsync(string userId, UserDto userDto);
        Task<IEnumerable<string>> GetUserRolesById(string id);
        Task RemoveFromRoleAsync(string userId, string role);
        Task AddToRoleAsync(string userId, string role);

        //for development purposes verify token is returning in request and probably will go to identity service
        Task<(Result, Guid, string)> CreateUserAsync(UserDto userDto, string password);
    }
}