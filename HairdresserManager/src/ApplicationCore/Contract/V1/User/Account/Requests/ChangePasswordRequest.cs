namespace ApplicationCore.Contract.V1.User.Account.Requests
{
    public class ChangePasswordRequest
    { 
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ReTypedNewPassword { get; set; }
    }
}