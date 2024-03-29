using System;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IJwtManager
    {
        Task<AuthenticationResult> RefreshTokensAsync(string accessToken, Guid refreshTokenId);
        Task<AuthenticationResult> CreateAuthenticationResultAsync(string userId);
        Task<AuthenticationResult> CreateAuthenticationResultAsync(UserDto userDto);
    }
}