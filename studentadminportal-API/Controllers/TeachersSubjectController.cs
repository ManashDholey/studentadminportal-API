using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;

namespace studentadminportal_API.Controllers
{
    public class TeachersSubjectController : BaseApiController
    {
        private readonly ITeachersSubjectServices _teachersSubjectServices;
        private readonly IMapper _mapper;

        public TeachersSubjectController(ITeachersSubjectServices teachersSubjectServices, IMapper mapper)
        {
            _teachersSubjectServices= teachersSubjectServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teacher = await _teachersSubjectServices.GetAllAsync();

            return Ok(_mapper.Map<List<TeacherSubjectDTO>>(teacher));
        }

        [HttpGet]
        [Route("{teacherId:guid}"), ActionName("GetTeacherSubjectByIdAsync")]
        public async Task<IActionResult> GetTeacherSubjectByIdAsync([FromRoute] Guid teacherId)
        {
            // Fetch Teacher Details
            var teacher = await _teachersSubjectServices.GetByIdAsync(teacherId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherSubjectDTO>(teacher));
        }

        [HttpPut]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid teacherId, [FromBody] TeacherDTO request)
        {
            if (await _teachersSubjectServices.Exists(teacherId))
            {
                // Update Details
                var updatedTeacher = await _teachersSubjectServices.Update(teacherId, _mapper.Map<TeacherSubject>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<TeacherSubjectDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{teacherId:guid}")]
        public async Task<IActionResult> DeleteTeachersAsync([FromRoute] Guid teacherId)
        {
            if (await _teachersSubjectServices.Exists(teacherId))
            {
                var teacher = await _teachersSubjectServices.Delete(teacherId);
                return Ok(_mapper.Map<TeacherSubjectDTO>(teacher));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherAttendanceDTO request)
        {
            var teacher = await _teachersSubjectServices.Add(_mapper.Map<TeacherSubject>(request));
            return CreatedAtAction(nameof(GetTeacherSubjectByIdAsync), new { classId = teacher.Id },
                _mapper.Map<TeacherSubjectDTO>(teacher));
        }
    }
}
