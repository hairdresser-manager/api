using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;

namespace ApplicationCore.Services
{
    public class JwtManager : IJwtManager
    {
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUserService _userService;

        public JwtManager(IJwtService jwtService, IRefreshTokenService refreshTokenService, IUserService userService)
        {
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _userService = userService;
        }

        public async Task<AuthenticationResult> CreateAuthenticationResultAsync(string userId)
        {
            var userDto = await _userService.GetUserDtoByIdAsync(userId);
            var newAccessTokenJti = Guid.NewGuid();

            var succeededResult = new AuthenticationResult
            {
                AccessToken = _jwtService.GetNewAccessToken(userDto, newAccessTokenJti),
                RefreshToken = await _refreshTokenService.CreateRefreshTokenAsync(userDto.Id, newAccessTokenJti)
            };

            return succeededResult;
        }

        public async Task<AuthenticationResult> RefreshTokensAsync(string accessToken, Guid refreshTokenId)
        {
            var accessTokenValidationResult = ValidateJwtToken(accessToken, out var jwtSecurityToken);

            if (!accessTokenValidationResult.Succeeded)
                return new AuthenticationResult(false, accessTokenValidationResult.Errors);

            var refreshTokenValidationResult = await ValidateRefreshTokenAsync(jwtSecurityToken, refreshTokenId);

            if (!refreshTokenValidationResult.Succeeded)
                return new AuthenticationResult(false, refreshTokenValidationResult.Errors);
            
            await _refreshTokenService.MakeUsedByIdAsync(refreshTokenId);

            return await CreateAuthenticationResultAsync(jwtSecurityToken.Subject);
        }

        private async Task<ServiceResult> ValidateRefreshTokenAsync(JwtSecurityToken jwtSecurityToken,
            Guid refreshTokenId)
        {
            Guid userId;
            Guid accessTokenJti;
            
            try
            {
                userId = Guid.Parse(jwtSecurityToken.Subject);
                accessTokenJti = Guid.Parse(jwtSecurityToken.Id);
            }
            catch 
            {
                return ServiceResult.Failure("invalid access token");
            }

            var refreshTokenValidationResult =
                await _refreshTokenService.ValidateRefreshTokenAsync(userId, refreshTokenId, accessTokenJti);

            if (!refreshTokenValidationResult.Succeeded)
                return ServiceResult.Failure(refreshTokenValidationResult.Errors);

            return ServiceResult.Success();
        }

        private ServiceResult ValidateJwtToken(string accessToken, out JwtSecurityToken jwtSecurityToken)
        {
            var serviceResult = _jwtService.ValidateJwtToken(accessToken, out jwtSecurityToken);

            if (!serviceResult.Succeeded)
                return serviceResult;
            
            return jwtSecurityToken.ValidTo > DateTime.UtcNow 
                ? ServiceResult.Failure("access token hasn't expired yet") 
                : serviceResult;
        }
    }
}