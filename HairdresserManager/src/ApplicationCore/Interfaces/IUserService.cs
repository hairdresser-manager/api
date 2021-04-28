using System;
using System.Threading.Tasks;
using ApplicationCore.Contract.V1.Register.Requests;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IUserService
    {
        Task<bool> UserExistsByEmailAsync(string email);
        Task<UserDTO> GetUserDtoByIdAsync(string userId);
        Task<Result> UpdateUserDataAsync(string userId, UserDTO userDto);
        string GetUserRoleById(string userId);

        //for development purposes verify token is returning in request and probably will go to identity service
        Task<(Result, Guid, string)> CreateUserAsync(RegisterRequest userDto);
    }
}