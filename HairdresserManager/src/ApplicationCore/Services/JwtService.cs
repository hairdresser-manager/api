using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Settings;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationCore.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        public JwtService(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public string GenerateAccessToken(UserDto user)
        {
            var accessTokenJti = Guid.NewGuid();
            var userEmail = user.Email;
            var userRole = user.Role;

            var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, accessTokenJti.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, userEmail),
                    new Claim("role", userRole)
                }),

                Expires = DateTime.UtcNow.AddSeconds(Convert.ToDouble(_jwtSettings.AccessTokenLifeTimeInSeconds)),
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}