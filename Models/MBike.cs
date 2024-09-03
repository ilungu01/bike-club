namespace bike_club.Models
{
    public class MBike : MBase
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Guid UserId { get; set; }
        public MUser User { get; set; }
    }
}
