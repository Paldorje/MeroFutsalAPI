namespace MeroFutsal.Models
{
    public partial class Futsal
    {
        public int Futsalid { get; set; }

        [Required(ErrorMessage = "Futsal Name field is required.")]
        [StringLength(maximumLength: 30, MinimumLength =5)]
        public string FutsalName { get; set;}
        public bool? Isreserved { get; set; }

        [Required(ErrorMessage = "Cost Field is required")]
        public int Cost { get; set; }
        public string Location { get; set; }
        public bool? Isdeleted { get; set; }
        public int Ownerid { get; set; }
    }
}
