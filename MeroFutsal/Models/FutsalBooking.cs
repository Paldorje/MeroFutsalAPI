namespace MeroFutsal.Models
{
    public class FutsalBooking
    {
        public int FutsalId { get; set; }

        public Futsal Futsal { get; set; }

        public int BookingId { get; set; }  

        public Booking Booking { get; set; }    
    }
}
