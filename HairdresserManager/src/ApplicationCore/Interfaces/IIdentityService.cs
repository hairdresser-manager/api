using System.Threading.Tasks;
using ApplicationCore.Results;

namespace ApplicationCore.Interfaces
{
    public interface IIdentityService
    {
        Task<Result> VerifyEmailAsync(string email, string token);
    }
}