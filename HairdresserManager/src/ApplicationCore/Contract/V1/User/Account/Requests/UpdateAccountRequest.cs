namespace ApplicationCore.Contract.V1.User.Account.Requests
{
    public class UpdateAccountRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
    }
}