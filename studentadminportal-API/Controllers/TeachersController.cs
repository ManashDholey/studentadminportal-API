using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TeachersController : BaseApiController
    {
        private readonly ITeachersServices _teachersServices;
        private readonly IMapper _mapper;

        public TeachersController(ITeachersServices teachersServices, IMapper mapper)
        {
            _teachersServices= teachersServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var teacher = await _teachersServices.GetTeachersAsync();

            return Ok(_mapper.Map<List<TeacherDTO>>(teacher));
        }

        [HttpGet]
        [Route("{teacherId:guid}"), ActionName("GetTeacherByIdAsync")]
        public async Task<IActionResult> GetTeacherByIdAsync([FromRoute] Guid teacherId)
        {
            // Fetch Teacher Details
            var teacher = await _teachersServices.GetTeacherByIdAsync(teacherId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherDTO>(teacher));
        }

        [HttpPut]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> UpdateTeachersAsync([FromRoute] Guid teacherId, [FromBody] TeacherDTO request)
        {
            if (await _teachersServices.Exists(teacherId))
            {
                // Update Details
                var updatedTeacher = await _teachersServices.UpdateTeacher(teacherId, _mapper.Map<Teacher>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<TeacherDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> DeleteTeacherAsync([FromRoute] Guid teacherId)
        {
            if (await _teachersServices.Exists(teacherId))
            {
                var teacher = await _teachersServices.DeleteTeacher(teacherId);
                return Ok(_mapper.Map<TeacherDTO>(teacher));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherDTO request)
        {
            var teacher = await _teachersServices.AddTeacher(_mapper.Map<Teacher>(request));
            return CreatedAtAction(nameof(GetTeacherByIdAsync), new { classId = teacher.Id },
                _mapper.Map<TeacherDTO>(teacher));
        }



    }
}
