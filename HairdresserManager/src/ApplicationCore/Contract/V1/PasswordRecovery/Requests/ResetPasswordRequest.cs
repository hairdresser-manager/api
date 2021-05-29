namespace ApplicationCore.Contract.V1.PasswordRecovery.Requests
{
    public class ResetPasswordRequest
    {
        public string ResetPasswordKey { get; set; }
        public string NewPassword { get; set; }
        public string ReTypedNewPassword { get; set; }
    }
}