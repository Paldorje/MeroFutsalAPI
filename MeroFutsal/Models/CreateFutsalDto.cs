namespace MeroFutsal.Models
{
    public class CreateFutsalDto
    {
        public int Futsalid { get; set; }
        public string FutsalName { get; set; }
        public bool? IsReserved { get; set; } = false;
        public int Cost { get; set; }
        public string Location { get; set; }
        public bool? IsDeleted { get; set; } = false;
        public string OwnerEmail { get; set; }
    }
}
