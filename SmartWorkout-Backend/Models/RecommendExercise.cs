using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class RecommendExercise
    {
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        [Required]
        public int Repetitions { get; set; }
    }
}
