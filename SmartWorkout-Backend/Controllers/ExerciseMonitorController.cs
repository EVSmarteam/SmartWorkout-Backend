using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using SmartWorkout_Backend.Services;
using System.Net;

namespace SmartWorkout_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class ExerciseMonitorController : BaseController
    {
        private readonly IExerciseMonitorService _exerciseMonitorService;
        public ExerciseMonitorController(IMapper mapper, IExerciseMonitorService exerciseMonitorService) : base(mapper)
        {
            _exerciseMonitorService = exerciseMonitorService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<List<ExerciseMonitorResource>>> GetAllExerciseMonitors()
        {
            var response = await _exerciseMonitorService.GetExercisesMonitor();
            var exerciseMonitorResources = _mapper.Map<List<ExerciseMonitorResource>>(response.Data);

            return new ApiResponse<List<ExerciseMonitorResource>>(HttpStatusCode.OK, response.Message, exerciseMonitorResources);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ApiResponse<ExerciseMonitorResource>> GetExerciseMonitorById(int id)
        {
            var response = await _exerciseMonitorService.GetExerciseMonitorById(id);
            var exerciseMonitorResource = _mapper.Map<ExerciseMonitorResource>(response.Data);

            return new ApiResponse<ExerciseMonitorResource>(HttpStatusCode.OK, response.Message, exerciseMonitorResource);
        }

        [Authorize]
        [HttpGet("User/{id}")]
        public async Task<ApiResponse<List<ExerciseMonitorResource>>> GetExerciseMonitorsByUserId(int id)
        {
            var response = await _exerciseMonitorService.GetExerciseMonitorByUserId(id);
            var exerciseMonitorResources = _mapper.Map<List<ExerciseMonitorResource>>(response.Data);

            return new ApiResponse<List<ExerciseMonitorResource>>(HttpStatusCode.OK, response.Message, exerciseMonitorResources);
        }
    }
}
