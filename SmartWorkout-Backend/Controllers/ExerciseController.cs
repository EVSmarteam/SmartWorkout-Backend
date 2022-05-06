using AutoMapper;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Models;
using SmartWorkout_Backend.Resources;
using SmartWorkout_Backend.Services;
using SmartWorkout_Backend.ViewModels;
using System.Net;

namespace SmartWorkout_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ExerciseController : BaseController
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IMapper mapper, IExerciseService exerciseService) : base(mapper)
        {
            _exerciseService = exerciseService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<List<ExerciseResource>>> GetAllExercises()
        {
            var response = await _exerciseService.GetExercises();
            var exerciseResources = _mapper.Map<List<ExerciseResource>>(response.Data);

            return new ApiResponse<List<ExerciseResource>>(HttpStatusCode.OK, response.Message, exerciseResources);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ApiResponse<ExerciseResource>> GetExerciseById(int id)
        {
            var response = await _exerciseService.GetExerciseById(id);
            var exerciseResource = _mapper.Map<ExerciseResource>(response.Data);

            return new ApiResponse<ExerciseResource>(HttpStatusCode.OK, response.Message, exerciseResource);
        }

        [Authorize]
        [HttpGet("Favorite/User/{id}")]
        public async Task<ApiResponse<List<FavoriteExerciseResource>>> GetFavoriteExercises(int id)
        {
            var response = await _exerciseService.GetFavoriteExercises(id);
            var favoriteExercises = _mapper.Map<List<FavoriteExerciseResource>>(response.Data);

            return new ApiResponse<List<FavoriteExerciseResource>>(HttpStatusCode.OK, response.Message, favoriteExercises);
        }

        [Authorize]
        [HttpGet("Recommend/User/{id}")]
        public async Task<ApiResponse<List<RecommendExerciseResource>>> GetRecommendExercises(int id)
        {
            var response = await _exerciseService.GetRecommendExercises(id);
            var recommendExercises = _mapper.Map<List<RecommendExerciseResource>>(response.Data);

            return new ApiResponse<List<RecommendExerciseResource>>(HttpStatusCode.OK, response.Message, recommendExercises);
        }

        [Authorize]
        [HttpPost("SaveFavorite")]
        public async Task<ApiResponse<FavoriteExerciseResource>> SaveFavorite(FavoriteExerciseViewModel favoriteExercise)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var newFavoriteExercise = _mapper.Map<FavoriteExercise>(favoriteExercise);
            var response = await _exerciseService.SaveFavoriteExercise(newFavoriteExercise);

            if (!response.Success)
                throw new ApiException(response.Message);

            var exerciseResource = _mapper.Map<FavoriteExerciseResource>(response.Data);

            return new ApiResponse<FavoriteExerciseResource>(HttpStatusCode.OK, response.Message, exerciseResource);
        }

        [Authorize]
        [HttpDelete("DeleteFavorite")]
        public async Task<ApiResponse<FavoriteExerciseResource>> DeleteFavorite(FavoriteExerciseViewModel favoriteExercise)
        {
            if (!ModelState.IsValid)
                throw new ApiException(ModelState.AllErrors());

            var existingFavoriteExercise = _mapper.Map<FavoriteExercise>(favoriteExercise);
            var response = await _exerciseService.DeleteFavoriteExercise(existingFavoriteExercise);

            if (!response.Success)
                throw new ApiException(response.Message);

            var exerciseResource = _mapper.Map<FavoriteExerciseResource>(response.Data);

            return new ApiResponse<FavoriteExerciseResource>(HttpStatusCode.OK, response.Message, exerciseResource);
        }
    }
}
