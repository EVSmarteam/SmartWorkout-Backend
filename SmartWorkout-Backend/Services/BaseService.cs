using SmartWorkout_Backend.Connection;

namespace SmartWorkout_Backend.Services
{
    public enum MessageType
    {        
        Success,
        Info,
        Error
    }
    public class BaseService
    {
        public readonly SmartWorkoutDbContext _context;

        public BaseService(SmartWorkoutDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public string PostMessage(Exception ex)
        {
            var message = "Ha ocurrido un problema al procesar la solicitud" + ex.Message;

            return message;
        }

        public string PostMessage(MessageType type)
        {
            var message = "";

            switch (type)
            {                
                case MessageType.Success: message = "Los datos se han registrado exitosamente"; break;
                case MessageType.Info: message = "Proceso exitoso"; break;
            }

            return message;
        }
    }
}
