using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Connection;
using SmartWorkout_Backend.Models;

namespace SmartWorkout_Backend.Services
{
    public interface IExerciseService
    {
        Task<InnerResponse> GetExercises();
        Task<InnerResponse> GetExerciseById(int id);
        Task<InnerResponse> GetFavoriteExercises(int id);
        Task<InnerResponse> SaveFavoriteExercise(FavoriteExercise favoriteExercise);
        Task<InnerResponse> DeleteFavoriteExercise(FavoriteExercise favoriteExercise);
    }
    public class ExerciseService : BaseService, IExerciseService
    {
        public ExerciseService(SmartWorkoutDbContext context) : base(context)
        {
        }       

        public async Task<InnerResponse> GetExerciseById(int id)
        {
            var exercise = await _context.Exercise.Include(x => x.Dumbbell)
                .SingleOrDefaultAsync(x => x.ExcerciseId == id);

            return new InnerResponse(true, PostMessage(MessageType.Info), exercise);
        }

        public async Task<InnerResponse> GetExercises()
        {
            var exercises = await _context.Exercise.Include(x => x.Dumbbell).ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), exercises);
        }

        public async Task<InnerResponse> SaveFavoriteExercise(FavoriteExercise favoriteExercise)
        {
            try
            {
                await _context.FavoriteExercise.AddAsync(favoriteExercise);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Success), favoriteExercise);

            }catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> DeleteFavoriteExercise(FavoriteExercise favoriteExercise)
        {
            try
            {
                _context.FavoriteExercise.Remove(favoriteExercise);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Info), favoriteExercise);

            }
            catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> GetFavoriteExercises(int id)
        {
            var favoriteExercises = await _context.FavoriteExercise.Include(x => x.Exercise)
                .Where(x => x.UserId == id)
                .ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), favoriteExercises);
        }
    }
}
