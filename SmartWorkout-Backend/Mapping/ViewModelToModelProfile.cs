using AutoMapper;
using SmartWorkout_Backend.Models;
using SmartWorkout_Backend.ViewModels;

namespace SmartWorkout_Backend.Mapping
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<FavoriteExerciseViewModel, FavoriteExercise>();
        }
    }
}
