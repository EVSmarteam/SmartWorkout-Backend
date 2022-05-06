namespace SmartWorkout_Backend.Resources
{
    public class UserResource
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string WearableId { get; set; }
        public float? Weigth { get; set; }
        public float? Height { get; set; }        
        public DateTime BirthDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
