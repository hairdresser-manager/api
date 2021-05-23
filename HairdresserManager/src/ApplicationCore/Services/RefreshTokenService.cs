using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using ApplicationCore.Settings;
using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IHairdresserDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public RefreshTokenService(IHairdresserDbContext context, JwtSettings jwtSettings)
        {
            _context = context;
            _jwtSettings = jwtSettings;
        }

        public async Task<string> CreateRefreshTokenAsync(Guid userId, Guid accessTokenJti)
        {
            var lifeTimeInDays = int.Parse(_jwtSettings.RefreshTokenLifeTimeInDays);

            var refreshToken = new RefreshToken
            {
                UserId = userId,
                AccessTokenJti = accessTokenJti,
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(lifeTimeInDays),
                Used = false
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync(new CancellationToken());

            return refreshToken.Id.ToString();
        }

        public async Task<ServiceResult> ValidateRefreshTokenAsync(Guid userId, Guid refreshTokenId,
            Guid accessTokenJti)
        {
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == refreshTokenId);

            if (refreshToken == null)
                return ServiceResult.Failure("refresh token doesn't exist");

            if (refreshToken.UserId != userId)
                return ServiceResult.Failure("refresh token isn't related with this user");

            if (refreshToken.AccessTokenJti != accessTokenJti)
                return ServiceResult.Failure("refresh token isn't related with this access token");

            return refreshToken.Used ? ServiceResult.Failure("refresh token is used") : ServiceResult.Success();
        }

        public async Task<bool> MakeUsedByIdAsync(Guid refreshTokenId)
        {
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Id == refreshTokenId);

            if (refreshToken == null)
                return false;

            refreshToken.Used = !refreshToken.Used;

            _context.RefreshTokens.Update(refreshToken);
            return await _context.SaveChangesAsync(new CancellationToken()) > 0;
        }
    }
}