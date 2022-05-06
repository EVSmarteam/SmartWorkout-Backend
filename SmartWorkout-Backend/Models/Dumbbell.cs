using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class Dumbbell
    {
        [Key]
        public int DumbbellId { get; set; }
        [Required]
        public string Name { get; set;}
        [Required]
        public string Description { get; set;}
        [Required]
        public float Weight { get; set;}
        [Required]
        public float Size { get; set;}
        public ICollection<Exercise> Exercise { get; set; }
    }
}
