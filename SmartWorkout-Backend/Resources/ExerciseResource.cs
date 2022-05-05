namespace SmartWorkout_Backend.Resources
{
    public class ExerciseResource
    {
        public int ExcerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DumbbellResource Dumbbell { get; set; }
    }
}
