using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Models;

namespace SmartWorkout_Backend.Connection
{
    public class SmartWorkoutDbContext : DbContext
    {
        public SmartWorkoutDbContext(DbContextOptions<SmartWorkoutDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
