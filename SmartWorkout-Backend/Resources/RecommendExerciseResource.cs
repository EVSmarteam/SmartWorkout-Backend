namespace SmartWorkout_Backend.Resources
{
    public class RecommendExerciseResource
    {
        public ExerciseResource Exercise { get; set; }
        public TimeSpan Duration { get; set; }
        public int Repetitions { get; set; }
    }
}
