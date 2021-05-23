using System;
using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IRefreshTokenService
    {
        public Task<string> CreateRefreshTokenAsync(Guid userId, Guid accessTokenJti);
        public Task<ServiceResult> ValidateRefreshTokenAsync(Guid userId, Guid refreshTokenId, Guid accessTokenJti);
        public Task<bool> MakeUsedByIdAsync(Guid refreshTokenId);
    }
}