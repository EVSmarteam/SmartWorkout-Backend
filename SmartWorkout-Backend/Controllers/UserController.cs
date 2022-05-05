using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartWorkout_Backend.Communication;
using SmartWorkout_Backend.Resources;
using SmartWorkout_Backend.Services;
using System.Net;

namespace SmartWorkout_Backend.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IMapper mapper, IUserService userService) : base(mapper)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ApiResponse<List<UserResource>>> GetAllUsers()
        {
            var response = await _userService.GetUsers();
            var usersResource = _mapper.Map<List<UserResource>>(response.Data);

            return new ApiResponse<List<UserResource>>(HttpStatusCode.OK, response.Message, usersResource);
        } 
    }
}
