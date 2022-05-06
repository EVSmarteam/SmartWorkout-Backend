using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class ExerciseMonitor
    {
        [Key]
        public int ExerciseMonitorId { get; set; }
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        public Exercise Exercise { get; set; }
        [Required]
        public int ExerciseId { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public float HeartRate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
