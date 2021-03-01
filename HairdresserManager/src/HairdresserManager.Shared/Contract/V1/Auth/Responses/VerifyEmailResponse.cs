namespace HairdresserManager.Shared.Contract.V1.Auth.Responses
{
    public class VerifyEmailResponse
    {
        private string _email;
        
        public string Message
        {
            get => $"Email {_email} is verified successfully, you can log in";
        }

        public string Email
        {
            set => _email = value;
        }
    }
}