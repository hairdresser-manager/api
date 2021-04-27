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
        Task<UserDTO> GetUserByEmailAsync(string email);
        
        //for development purposes verify token is returning in request
        Task<(Result, Guid, string)> CreateUserAsync(RegisterRequest userDto);
        Task<Result> VerifyEmailAsync(string emailToken, string verifyEmailToken);
    }
}