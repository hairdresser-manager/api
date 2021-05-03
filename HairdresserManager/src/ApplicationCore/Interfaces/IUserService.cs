using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserDtoByEmailAsync(string email);
        Task<UserDto> GetUserDtoByIdAsync(string userId);
        Task<Result> UpdateUserDataAsync(string userId, UserDto userDto);
        string GetUserRoleById(string userId);

        //for development purposes verify token is returning in request and probably will go to identity service
        Task<(Result, Guid, string)> CreateUserAsync(UserDto userDto, string password);
    }
}