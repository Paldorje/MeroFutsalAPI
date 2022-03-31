namespace MeroFutsal.Models
{
    public partial class Ground
    {
        

        public int Groundid { get; set; }

        public string GroundName { get; set; }
        public int Futsalid { get; set; }
        public bool? Isreserved { get; set; }
        public bool? Isdeleted { get; set; }

        public virtual ICollection<Futsal> Futsals { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }
    }
}