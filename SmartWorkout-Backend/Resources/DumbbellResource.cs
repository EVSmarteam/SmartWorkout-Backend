namespace SmartWorkout_Backend.Resources
{
    public class DumbbellResource
    {
        public int DumbbellId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Weight { get; set; }
        public float Size { get; set; }
        public ICollection<ExerciseResource> Exercise { get; set; }
    }
}
