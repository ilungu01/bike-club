namespace bike_club.Models
{
    public class MMembership : MBase
    {
        public Guid UserId { get; set; }
        public MUser User { get; set; }
        public Guid MembershipTypeId { get; set; }
        public MMembershipType MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
