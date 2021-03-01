using System.Threading.Tasks;
using HairdresserManager.Shared.Contract.V1.Auth.Responses;
using HairdresserManager.Shared.Results;

namespace HairdresserManager.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<LoginResponse>> LoginAsync();
        Task<ServiceResult<LogoutResponse>> LogoutAsync();
        Task<ServiceResult<RegisterResponse>> RegisterAsync();
        Task<ServiceResult<FacebookAuthResponse>> FacebookAuthAsync();
        Task<ServiceResult<RefreshTokenResponse>> RefreshTokenAsync();
        Task<ServiceResult<RemindPasswordResponse>> RemindPasswordAsync();
        Task<ServiceResult<ResetPasswordResponse>> ResetPasswordAsync();
        Task<ServiceResult<VerifyEmailResponse>> VerifyEmailAsync();
    }
}