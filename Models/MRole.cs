namespace bike_club.Models
{
    public class MRole : MBase
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public ICollection<MUser> Users { get; set; }
    }
}
