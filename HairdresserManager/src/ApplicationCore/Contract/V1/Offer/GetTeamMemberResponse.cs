namespace ApplicationCore.Contract.V1.Offer
{
    public class GetTeamMemberResponse
    {
        public int EmployeeId { get; set; }
        public string Nick { get; set; }
        public string Description { get; set; }
        public string AvatarUrl { get; set; }
    }
}