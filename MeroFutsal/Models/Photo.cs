namespace MeroFutsal.Models
{
    public partial class Photo
    {
        public int Photoid { get; set; }
        public int Futsalid { get; set; }

        public string PhotoName { get; set; }

        public virtual Futsal Futsal { get; set; }
    }
}
