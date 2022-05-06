using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class FavoriteExercise
    {
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public int ExerciseId { get; set; }
    }
}
