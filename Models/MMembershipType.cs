namespace bike_club.Models
{
    public class MMembershipType : MBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubscriptionLengthInMonths { get; set; }
        
        public ICollection<MMembership> Memberships { get; set; }
    }
}
