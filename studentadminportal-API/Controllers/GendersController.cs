using AutoMapper;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;


namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class GendersController : BaseApiController
    {
        private readonly IStudentServices _studentServices;
        private readonly IMapper _mapper;

        public GendersController(IStudentServices studentServices, IMapper mapper)
        {
            _studentServices = studentServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await _studentServices.GetGendersAsync();

            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }

            return Ok(_mapper.Map<List<GenderDTO>>(genderList));
        }
    }
}
