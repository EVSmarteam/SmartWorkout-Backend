using Microsoft.EntityFrameworkCore;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Connection;
using SmartWorkout_Backend.Models;

namespace SmartWorkout_Backend.Services
{
    public interface IUserService
    {
        Task<InnerResponse> GetUsers();
        Task<InnerResponse> GetUserById(int id);
        Task<InnerResponse> SaveUser(User user);
        Task<InnerResponse> UpdateUser(int id);
        Task<InnerResponse> DeleteUser(int id);
    }

    public class UserService : BaseService, IUserService
    {
        public UserService(SmartWorkoutDbContext context) : base(context)
        {
        }

        public Task<InnerResponse> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<InnerResponse> GetUsers()
        {
            var users = await _context.User.OrderBy(x => x.CreatedAt).ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), users);
        }

        public Task<InnerResponse> SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<InnerResponse> UpdateUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
