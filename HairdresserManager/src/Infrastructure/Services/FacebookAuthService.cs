using System.Net.Http;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Results;
using ApplicationCore.Settings;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Services
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string DebugFbTokenUrl =
            "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}"; //access_token to verify, app_id, secret_id ;

        private const string
            ReadFbUserInfoUrl =
                "https://graph.facebook.com/me?fields=email,first_name,last_name&access_token={0}"; //access_token

        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FacebookAuthSettings _facebookAuthSettings;

        public FacebookAuthService(IHttpClientFactory httpClientFactory, FacebookAuthSettings facebookAuthSettings)
        {
            _httpClientFactory = httpClientFactory;
            _facebookAuthSettings = facebookAuthSettings;
        }

        public async Task<FacebookAuthResult> AuthUserByFbTokenAsync(string accessToken)
        {
            if (!await ValidateFacebookAccessTokenAsync(accessToken))
                return new FacebookAuthResult {Success = false, ErrorMessage = "Invalid access token"};

            return await GetUserInfoAsync(accessToken);
        }

        private async Task<bool> ValidateFacebookAccessTokenAsync(string accessToken)
        {
            var requestUrl = string.Format(DebugFbTokenUrl, accessToken, _facebookAuthSettings.AppId,
                _facebookAuthSettings.AppSecret);
            var response = await _httpClientFactory.CreateClient().GetAsync(requestUrl);

            var parsedObject = JObject.Parse(await response.Content.ReadAsStringAsync());

            try
            {
                var isValid = parsedObject["data"]["is_valid"];
                return (bool) isValid;
            }
            catch
            {
                return false;
            }
        }

        private async Task<FacebookAuthResult> GetUserInfoAsync(string accessToken)
        {
            var requestUrl = string.Format(ReadFbUserInfoUrl, accessToken);
            var response = await _httpClientFactory.CreateClient().GetAsync(requestUrl);

            var parsedObject = JObject.Parse(await response.Content.ReadAsStringAsync());

            var result = new FacebookAuthResult();

            try
            {
                result.Email = parsedObject["email"].ToString();
                result.Id = parsedObject["id"].ToString();
                result.FirstName = parsedObject["first_name"].ToString();
                result.LastName = parsedObject["last_name"].ToString();
                result.Success = true;
            }
            catch
            {
                result.Success = false;
                result.ErrorMessage = "Something went wrong while processing facebook response";
            }

            return result;
        }
    }
}