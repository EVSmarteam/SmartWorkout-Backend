using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string WearableId { get; set; }
        public float? Weigth { get; set; }
        public float? Height { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }        
    }
}
