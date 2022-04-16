namespace MeroFutsal.Models
{
    public class UserBooking
    {
        [Key]
        public string UserEmail { get; set; }

        public User User { get; set; }


        public int BookingId { get; set; }

        public Booking Booking { get; set; }
    }
}
