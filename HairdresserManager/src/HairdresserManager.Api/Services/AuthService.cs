using System;
using System.Threading.Tasks;
using HairdresserManager.Api.Services.Interfaces;
using HairdresserManager.Shared.Contract.V1.Auth.Responses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services
{
    public class AuthService : IAuthService
    {
        public async Task<ServiceResult<LoginResponse>> LoginAsync()
        {
            const string accessToken =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            var refreshToken = Guid.NewGuid();
            var response = new LoginResponse {AccessToken = accessToken, RefreshToken = refreshToken};
            return new ServiceResult<LoginResponse> {Success = true, Data = response};
        }

        public async Task<ServiceResult<LogoutResponse>> LogoutAsync()
        {
            return new() {Success = true, ResponseCode = 204};
        }

        public async Task<ServiceResult<RegisterResponse>> RegisterAsync()
        {
            return new()
            {
                Success = true, ResponseCode = 201,
                Data = new RegisterResponse {ConfirmEmailUri = "api/v1/verify-email/" + Guid.NewGuid()}
            };
        }

        public async Task<ServiceResult<FacebookAuthResponse>> FacebookAuthAsync()
        {
            const string accessToken =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            var refreshToken = Guid.NewGuid();
            var response = new FacebookAuthResponse {AccessToken = accessToken, RefreshToken = refreshToken};
            return new ServiceResult<FacebookAuthResponse> {Success = true, Data = response};
        }

        public async Task<ServiceResult<RefreshTokenResponse>> RefreshTokenAsync()
        {
            const string accessToken =
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
            var refreshToken = Guid.NewGuid();
            var response = new RefreshTokenResponse {AccessToken = accessToken, RefreshToken = refreshToken};
            return new ServiceResult<RefreshTokenResponse> {Success = true, Data = response};
        }

        public async Task<ServiceResult<RemindPasswordResponse>> RemindPasswordAsync()
        {
            var response = new RemindPasswordResponse
                {Email = "user@example.com", ResetPasswordKey = Guid.NewGuid().ToString()};
            return new ServiceResult<RemindPasswordResponse>() {Success = true, Data = response};
        }

        public async Task<ServiceResult<ResetPasswordResponse>> ResetPasswordAsync()
        {
            return new() {Success = true, ResponseCode = 204};
        }

        public async Task<ServiceResult<VerifyEmailResponse>> VerifyEmailAsync()
        {
            return new() {Success = true, ResponseCode = 204};
        }
    }
}