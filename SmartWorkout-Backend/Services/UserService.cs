using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartWorkout_Backend.Authentication;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Connection;
using SmartWorkout_Backend.Models;
using BC = BCrypt.Net.BCrypt;

namespace SmartWorkout_Backend.Services
{
    public interface IUserService
    {
        Task<InnerResponse> Authenticate(AuthenticateRequest model);
        Task<InnerResponse> IdentifyUser(string authHeader);
        Task<InnerResponse> GetUsers();
        Task<InnerResponse> GetUserById(int id);
        Task<InnerResponse> SaveUser(User user);
        Task<InnerResponse> UpdateUser(User user);
        Task<InnerResponse> DeleteUser(int id);
        Task<InnerResponse> UpdateUserWereable(int id, string wearableId);
    }

    public class UserService : BaseService, IUserService
    {
        private readonly JwtToken _jwtToken;
        private readonly AppSettings _appSettings;
        public UserService(SmartWorkoutDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
            _jwtToken = new JwtToken(_appSettings);
        }

        public async Task<InnerResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _context.User.SingleOrDefaultAsync(x => x.Email == model.Email);

            if (user == null || !BC.Verify(model.Password, user.Password))
                return new InnerResponse(false, "No existe el usuario o Email y/o contraseña incorrecta", null);
            else
            {
                var token = _jwtToken.GenerateJwtToken(user);

                return new InnerResponse(true, "Identificacion Exitosa", new AuthenticateResponse(user, token));
            }
        }

        public async Task<InnerResponse> IdentifyUser(string authHeader)
        {
            var id = _jwtToken.ExtractFromJwtToken(authHeader);
            if (id != null)
            {
                var user = await _context.User.FirstOrDefaultAsync(x => x.UserId == int.Parse(id));

                return new InnerResponse(true, "Identificacion Exitosa", user);
            }
            else            
                return new InnerResponse(false, "No existe el usuario o token incorrecto", null);
            
        }

        public async Task<InnerResponse> GetUsers()
        {
            var users = await _context.User.OrderBy(x => x.CreatedAt).ToListAsync();

            return new InnerResponse(true, PostMessage(MessageType.Info), users);
        }        

        public async Task<InnerResponse> GetUserById(int id)
        {
            var user = await _context.User.FindAsync(id);

            return new InnerResponse(true, PostMessage(MessageType.Info), user);
        }           

        public async Task<InnerResponse> SaveUser(User user)
        {
            try
            {
                await _context.User.AddAsync(user);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Success), user);

            }catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> UpdateUser(User user)
        {
            try
            {
                user.UpdatedAt = DateTime.UtcNow;
                _context.User.Update(user);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Success), user);

            }
            catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> UpdateUserWereable(int id, string wearableId)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                user.UpdatedAt = DateTime.UtcNow;
                user.WearableId = wearableId;
                _context.User.Update(user);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Success), user);

            }
            catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }

        public async Task<InnerResponse> DeleteUser(int id)
        {
            try
            {
                var user = await GetUserById(id);
                var deletedUser = user.Data as User;
                deletedUser.DeletedAt = DateTime.UtcNow;
                deletedUser.IsDeleted = true;
                _context.User.Update(deletedUser);
                await SaveAsync();

                return new InnerResponse(true, PostMessage(MessageType.Success), deletedUser);

            }
            catch (Exception ex)
            {
                return new InnerResponse(false, PostMessage(ex), null);
            }
        }
    }
}
