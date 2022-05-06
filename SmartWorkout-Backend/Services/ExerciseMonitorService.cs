using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Connection;

namespace SmartWorkout_Backend.Services
{
    public interface IExerciseMonitorService
    {
        Task<InnerResponse> GetExercisesMonitor();
        Task<InnerResponse> GetExerciseMonitorByUserId(int id);
        Task<InnerResponse> GetExerciseMonitorById(int id);
    }
    public class ExerciseMonitorService : BaseService, IExerciseMonitorService
    {
        public ExerciseMonitorService(SmartWorkoutDbContext context) : base(context)
        {
        }

        public async Task<InnerResponse> GetExercisesMonitor()
        {
            var monitorExercises = await _context.ExerciseMonitor.Include(x => x.Exercise)
                .ThenInclude(x => x.Dumbbell)
                .Include(x => x.User)
                .ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), monitorExercises);
        }

        public async Task<InnerResponse> GetExerciseMonitorById(int id)
        {
            var monitorExercise = await _context.ExerciseMonitor.Include(x => x.Exercise)
                .ThenInclude(x => x.Dumbbell)
                .Include(x => x.User)
                .SingleOrDefaultAsync(x => x.ExerciseMonitorId == id);

            return new InnerResponse(true, PostMessage(MessageType.Info), monitorExercise);
        }

        public async Task<InnerResponse> GetExerciseMonitorByUserId(int id)
        {
            var monitorExercises = await _context.ExerciseMonitor.Include(x => x.Exercise)
                .ThenInclude(x => x.Dumbbell)
                .Where(x => x.UserId == id)
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), monitorExercises);
        }
    }
}
