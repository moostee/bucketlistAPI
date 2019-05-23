using System.ComponentModel.DataAnnotations;

namespace bucketListAPIModels
{
    public class LoginModel
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
