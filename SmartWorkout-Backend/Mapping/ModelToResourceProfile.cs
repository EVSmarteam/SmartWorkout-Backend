using AutoMapper;
using SmartWorkout_Backend.Models;
using SmartWorkout_Backend.Resources;

namespace SmartWorkout_Backend.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<User, UserResource>()
                .ForMember(u => u.FullName, opt => opt
                .MapFrom(us => us.FirstName + " " + us.LastName));
            CreateMap<Dumbbell, DumbbellResource>();
            CreateMap<Exercise, ExerciseResource>();
            CreateMap<FavoriteExercise, FavoriteExerciseResource>();
        }
    }
}
