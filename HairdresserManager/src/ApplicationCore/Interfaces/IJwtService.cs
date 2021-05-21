using System;
using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
    public interface IJwtService
    {
        string CreateAccessToken(UserDto userDto, Guid accessTokenJti);
    }
}