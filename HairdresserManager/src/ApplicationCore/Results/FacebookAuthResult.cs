namespace ApplicationCore.Results
{
    public class FacebookAuthResult 
    {
        public bool Success { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string ErrorMessage { get; set; }
    }
}