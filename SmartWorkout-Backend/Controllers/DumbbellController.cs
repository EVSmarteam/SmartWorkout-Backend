using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class DumbbellController : BaseController
    {
        private readonly IDumbbellService _dumbbellService;

        public DumbbellController(IMapper mapper, IDumbbellService dumbbellService) : base(mapper)
        {
            _dumbbellService = dumbbellService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ApiResponse<List<DumbbellResource>>> GetAllDumbbells()
        {
            var response = await _dumbbellService.GetDumbbells();
            var dumbbellsResource = _mapper.Map<List<DumbbellResource>>(response.Data);

            return new ApiResponse<List<DumbbellResource>>(HttpStatusCode.OK, response.Message, dumbbellsResource);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ApiResponse<DumbbellResource>>GetDumbbellById(int id)
        {
            var response = await _dumbbellService.GetDumbbellById(id);
            var dumbbellResource = _mapper.Map<DumbbellResource>(response.Data);

            return new ApiResponse<DumbbellResource>(HttpStatusCode.OK, response.Message, dumbbellResource);
        }
    }
}
