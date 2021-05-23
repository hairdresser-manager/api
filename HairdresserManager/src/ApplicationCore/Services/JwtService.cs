using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using ApplicationCore.Settings;
using Microsoft.IdentityModel.Tokens;

namespace ApplicationCore.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtService(JwtSettings jwtSettings, TokenValidationParameters tokenValidationParameters)
        {
            _jwtSettings = jwtSettings;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public string GetNewAccessToken(UserDto user, Guid accessTokenJti)
        {
            var userEmail = user.Email;
            var userRoles = user.Roles;

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, accessTokenJti.ToString()),
                new(JwtRegisteredClaimNames.Email, userEmail)
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = Encoding.ASCII.GetBytes(_jwtSettings.SigningKey);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(Convert.ToDouble(_jwtSettings.AccessTokenLifeTimeInSeconds)),
                Issuer = _jwtSettings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public ServiceResult ValidateJwtToken(string accessToken, out JwtSecurityToken validatedToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            validatedToken = null;

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;

                tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out var securityToken);
                
                validatedToken = (JwtSecurityToken) securityToken;
                return ServiceResult.Success();
            }
            catch (SecurityTokenInvalidSignatureException)
            {
                return ServiceResult.Failure("signature of Access Token isn't valid");
            }
            catch (ArgumentException)
            {
                return ServiceResult.Failure("wrong access token format");
            }
            catch (SecurityTokenExpiredException)
            {
                return ServiceResult.Failure("access token is expired");
            }
            catch
            {
                return ServiceResult.Failure("you access token cannot be validated");
            }
        }
    }
}