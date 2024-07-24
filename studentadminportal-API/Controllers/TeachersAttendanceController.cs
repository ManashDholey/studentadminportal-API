using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TeachersAttendanceController : BaseApiController
    {
        private readonly ITeachersAttendanceServices _teachersServices;
        private readonly IMapper _mapper;

        public TeachersAttendanceController(ITeachersAttendanceServices teachersServices, IMapper mapper)
        {
            _teachersServices = teachersServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teacher = await _teachersServices.GetAllAsync();

            return Ok(_mapper.Map<List<TeacherAttendanceDTO>>(teacher));
        }

        [HttpGet]
        [Route("{teacherId:guid}"), ActionName("GetTeacherAttendanceByIdAsync")]
        public async Task<IActionResult> GetTeacherAttendanceByIdAsync([FromRoute] Guid teacherId)
        {
            // Fetch Teacher Details
            var teacher = await _teachersServices.GetByIdAsync(teacherId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherAttendanceDTO>(teacher));
        }

        [HttpPut]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid teacherId, [FromBody] TeacherDTO request)
        {
            if (await _teachersServices.Exists(teacherId))
            {
                // Update Details
                var updatedTeacher = await _teachersServices.Update(teacherId, _mapper.Map<TeacherAttendance>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<TeacherAttendanceDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> DeleteTeachersAsync([FromRoute] Guid teacherId)
        {
            if (await _teachersServices.Exists(teacherId))
            {
                var teacher = await _teachersServices.Delete(teacherId);
                return Ok(_mapper.Map<TeacherAttendanceDTO>(teacher));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherAttendanceDTO request)
        {
            var teacher = await _teachersServices.Add(_mapper.Map<TeacherAttendance>(request));
            return CreatedAtAction(nameof(GetTeacherAttendanceByIdAsync), new { classId = teacher.Id },
                _mapper.Map<TeacherAttendanceDTO>(teacher));
        }
    }
}
