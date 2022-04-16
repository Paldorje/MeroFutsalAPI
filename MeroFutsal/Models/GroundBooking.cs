namespace MeroFutsal.Models
{
    public class GroundBooking
    {
        public int GroundId { get; set; }

        public Ground Ground { get; set; }

        public int BookingId { get; set; }  

        public Booking Booking { get; set; }    
    }
}
