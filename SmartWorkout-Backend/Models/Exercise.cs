using System.ComponentModel.DataAnnotations;

namespace SmartWorkout_Backend.Models
{
    public class Exercise
    {
        [Key]
        public int ExcerciseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public Dumbbell Dumbbell { get; set; }
        public int DumbbellId { get; set; }        
    }
}
