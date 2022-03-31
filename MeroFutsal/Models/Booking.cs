namespace MeroFutsal.Models
{
    public partial class Booking
    {
        public int Bookingid { get; set; }
        public int Userid { get; set; }
        public int Groundid { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime BookingTime { get; set; }
        public User User { get; set; }
        public Ground Ground { get; set; }
    }
}
