namespace HairdresserManager.Shared.Contract.V1.Auth.Responses
{
    public class RemindPasswordResponse
    {
        private string _email;
        private string _resetPasswordKey;
        
        public string Message
        {
            get => $"Reset password key was sent to {_email} email address";
        }

        public string RedirectUri
        {
            get => $"/api/v1/auth/reset-password/{_resetPasswordKey}";
        }

        public string Email
        {
            set => _email = value;
        }

        public string ResetPasswordKey
        {
            set => _resetPasswordKey = value;
        }
    }
}