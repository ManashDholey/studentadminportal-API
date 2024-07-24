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
    public class StudentAttendanceController : BaseApiController
    {
        private readonly IStudentsAttendanceServices _studentsAttendanceServices;
        private readonly IMapper _mapper;

        public StudentAttendanceController(IStudentsAttendanceServices studentsAttendanceServices, IMapper mapper)
        {
            _studentsAttendanceServices = studentsAttendanceServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teacher = await _studentsAttendanceServices.GetAllAsync();

            return Ok(_mapper.Map<List<StudentAttendanceDTO>>(teacher));
        }

        [HttpGet]
        [Route("{teacherId:guid}"), ActionName("GetTeacherAttendanceByIdAsync")]
        public async Task<IActionResult> GetTeacherAttendanceByIdAsync([FromRoute] Guid teacherId)
        {
            // Fetch Teacher Details
            var teacher = await _studentsAttendanceServices.GetByIdAsync(teacherId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentAttendanceDTO>(teacher));
        }

        [HttpPut]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid teacherId, [FromBody] TeacherDTO request)
        {
            if (await _studentsAttendanceServices.Exists(teacherId))
            {
                // Update Details
                var updatedTeacher = await _studentsAttendanceServices.Update(teacherId, _mapper.Map<StudentAttendance>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<StudentAttendanceDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> DeleteTeachersAsync([FromRoute] Guid teacherId)
        {
            if (await _studentsAttendanceServices.Exists(teacherId))
            {
                var teacher = await _studentsAttendanceServices.Delete(teacherId);
                return Ok(_mapper.Map<StudentAttendanceDTO>(teacher));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherAttendanceDTO request)
        {
            var teacher = await _studentsAttendanceServices.Add(_mapper.Map<StudentAttendance>(request));
            return CreatedAtAction(nameof(GetTeacherAttendanceByIdAsync), new { classId = teacher.Id },
                _mapper.Map<StudentAttendanceDTO>(teacher));
        }

    }
}
