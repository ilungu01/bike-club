namespace bike_club.Models
{
    public class MRole
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public ICollection<MUser> Users { get; set; }
    }
}
