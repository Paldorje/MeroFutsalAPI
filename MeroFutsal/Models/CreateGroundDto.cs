namespace MeroFutsal.Models
{
    public class CreateGroundDto
    {
        public int Groundid { get; set; }

        public string GroundName { get; set; }
        public bool? Isreserved { get; set; } = false;
        public bool? Isdeleted { get; set; } = false;
        public int Futsalid { get; set; }
    }
}
