using System.ComponentModel.DataAnnotations;

namespace APICourseUdemy.DOTS
{
    public class RegisterDots
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }
}
