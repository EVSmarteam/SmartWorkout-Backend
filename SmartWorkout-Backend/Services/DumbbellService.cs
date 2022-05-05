using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Connection;

namespace SmartWorkout_Backend.Services
{
    public interface IDumbbellService
    {
        Task<InnerResponse> GetDumbbells();
        Task<InnerResponse> GetDumbbellById(int id);
    }
    public class DumbbellService : BaseService, IDumbbellService
    {
        public DumbbellService(SmartWorkoutDbContext context) : base(context)
        {
        }

        public async Task<InnerResponse> GetDumbbellById(int id)
        {
            var dumbbell = await _context.Dumbbell.Include(x=> x.Exercise)
                .SingleOrDefaultAsync(x => x.DumbbellId == id);

            return new InnerResponse(true, PostMessage(MessageType.Info), dumbbell);
        }

        public async Task<InnerResponse> GetDumbbells()
        {
            var dumbbells = await _context.Dumbbell.Include(x => x.Exercise).ToListAsync();
                
            return new InnerResponse(true, PostMessage(MessageType.Info), dumbbells);
        }
    }
}
