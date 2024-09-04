using System.Data;

namespace bike_club.Models
{
    public class MUser : MBase
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
        public MRole Role { get; set; }
        public ICollection<MBike>? Bike { get; set; }
        public ICollection<MMembership>? Memberships { get; set; }
    }
}
