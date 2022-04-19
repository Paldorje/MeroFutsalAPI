namespace MeroFutsal.Models
{
    public class Owner
    {
        //[Key]
        //[Required(ErrorMessage = "user ID is required.")]
        //public int Ownerid { get; set; }

        [Key]
        [Required(ErrorMessage = "Email field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        [EmailAddress]
        
        public string Email { get; set; }

        [Required(ErrorMessage = "Name field is required.")]
        [StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }


        [StringLength(maximumLength: 250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone field is required.")]
        [StringLength(maximumLength: 10, MinimumLength = 5)]
        public string? Phone { get; set; }

        public string? Photo { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/2/24/Baby_Madison_-_Soccer_%28Cameroon%29.png";

        public bool? IsAvailable { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;

        [JsonIgnore]
        public IList<Futsal>? futsals { get; set; }
    }
}
