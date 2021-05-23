using System;
using System.IdentityModel.Tokens.Jwt;
using ApplicationCore.DTOs;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IJwtService
    {
        string GetNewAccessToken(UserDto userDto, Guid accessTokenJti);
        ServiceResult ValidateJwtToken(string accessToken, out JwtSecurityToken validatedToken);
    }
}