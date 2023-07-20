using System.ComponentModel.DataAnnotations;

namespace SLData.Shared
{
    public class User
    {

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
