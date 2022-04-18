namespace MeroFutsal.Models
{
    public class Ground
    {

        public int Groundid { get; set; }

        public string GroundName { get; set; }
        public bool? Isreserved { get; set; } = false;
        public bool? Isdeleted { get; set; } = false;

        [JsonIgnore]
        public Futsal Futsals { get; set; }

        public int Futsalid { get; set; }
    }
}