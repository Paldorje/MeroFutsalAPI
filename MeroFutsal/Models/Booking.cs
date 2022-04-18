namespace MeroFutsal.Models
{
    public class Booking
    {
     

            public int Bookingid { get; set; }
            public string CurrentUserEmail { get; set; }
            public int Futsaldid { get; set; }
            public bool? Isdeleted { get; set; } = false;
            public DateTime BookingTime { get; set; }

        [JsonIgnore]
        public IList<FutsalBooking>? FutsalBookings { get; set; }

        [JsonIgnore]
        public IList<UserBooking>? UserBookings { get; set; }

    }

}
