using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Models;

namespace SmartWorkout_Backend.Connection
{
    public class SmartWorkoutDbContext : DbContext
    {
        public SmartWorkoutDbContext(DbContextOptions<SmartWorkoutDbContext> options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavoriteExercise>().HasKey(x => new { x.UserId, x.ExerciseId });
        }

        public DbSet<User> User { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Dumbbell> Dumbbell { get; set; }
        public DbSet<FavoriteExercise> FavoriteExercise { get; set; }

    }
}
