using bike_club.Models;

namespace bike_club.ViewModels
{
    public class LoginViewModel
    {
        public List<MUser> Users { get; set; }
        public List<MBike> Bikes { get; set; }
    }
}
