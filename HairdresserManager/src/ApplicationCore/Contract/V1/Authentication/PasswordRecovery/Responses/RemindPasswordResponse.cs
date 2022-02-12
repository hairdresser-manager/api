namespace ApplicationCore.Contract.V1.Authentication.PasswordRecovery.Responses
{
    public class RemindPasswordResponse
    {
        private readonly string _resetPasswordKey;
        
        public string SetNewPasswordUrl => $"/api/v1/auth/reset-password/{_resetPasswordKey}";
        public string Message => "Url to set new password was send to user@example.com";

        public string ResetPasswordKey
        {
            init => _resetPasswordKey = value;
        }
    }
}