using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IFacebookAuthService
    {
        Task<FacebookAuthResult> AuthUserByFbTokenAsync(string accessToken);
    }
}