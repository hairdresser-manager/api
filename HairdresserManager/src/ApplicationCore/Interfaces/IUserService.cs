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
        Task<ServiceResult> UpdateUserDataAsync(string userId, UserDto userDto);
        Task<IEnumerable<string>> GetUserRolesById(string id);
        Task RemoveFromRoleAsync(string userId, string role);
        Task AddToRoleAsync(string userId, string role);
        Task<bool> UserExistsAsync(string email);
        Task<ServiceResult> CreateExternalServiceUserAsync(UserDto userDto);

        //for development purposes verify token is returning in request and probably will go to identity service
        Task<(ServiceResult, Guid, string)> CreateUserAsync(UserDto userDto, string password);
    }
}