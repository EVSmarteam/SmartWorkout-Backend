using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string? WearableId { get; set; }
        public float? Weigth { get; set; }
        public float? Height { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }        
    }
}
