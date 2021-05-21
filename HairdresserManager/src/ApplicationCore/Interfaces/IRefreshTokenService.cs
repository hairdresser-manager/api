using System;
using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IRefreshTokenService
    {
        public Task<TokenValidationResult> ValidateRefreshTokenAsync(string refreshTokenId);
        public Task<string> CreateRefreshTokenAsync(Guid userId, Guid accessTokenJti);
    }
}