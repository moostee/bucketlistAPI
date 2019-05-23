using System.ComponentModel.DataAnnotations;

namespace bucketListAPIModels
{
    public class Signup
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
