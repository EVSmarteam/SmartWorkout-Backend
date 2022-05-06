using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Resources
{
    public class ExerciseMonitorResource
    {        
        public int ExerciseMonitorId { get; set; }
        public UserResource User { get; set; }        
        public ExerciseResource Exercise { get; set; }
        public TimeSpan Time { get; set; }
        public float HeartRate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
