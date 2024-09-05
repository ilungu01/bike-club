using bike_club.Models;

namespace bike_club.ViewModels
{
    public class BikeViewModel
    {
        public MBike Bike{ get; set; }

        public Guid UserId { get; set; }
    }
}
