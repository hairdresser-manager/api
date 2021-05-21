using System;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using ApplicationCore.Settings;

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

        public Task<TokenValidationResult> ValidateRefreshTokenAsync(string refreshTokenId)
        {
            throw new NotImplementedException();
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
    }
}