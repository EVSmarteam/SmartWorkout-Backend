using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
