namespace MeroFutsal.Models

{
    public partial class Futsal
    {
        public int Futsalid { get; set; }

        [Required(ErrorMessage = "Futsal Name field is required.")]
        [StringLength(maximumLength: 30, MinimumLength =5)]
        public string FutsalName { get; set;}
        public bool? IsReserved { get; set; } = false;

        [Required(ErrorMessage = "Cost Field is required")]
        public int Cost { get; set; }
        public string Location { get; set; }
        public bool? IsDeleted { get; set; } = false ;

       [JsonIgnore]
        public  Owner Owners { get; set; }

        [Required(ErrorMessage = "Owner Email is Required.")]
        [EmailAddress]
        public string OwnerEmail { get; set; }

        [JsonIgnore]
        public List<Ground> Grounds { get; set; }

        [JsonIgnore]
        public IList<FutsalBooking>? FutsalBookings { get; set; }
    }
}
