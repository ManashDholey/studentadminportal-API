using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;
using studentadminportal_API.Helpers;

namespace studentadminportal_API.Controllers
{
    [AuthorizeAttribute]
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
        [Route("{teacherSubjectId:guid}"), ActionName("GetTeacherSubjectByIdAsync")]
        public async Task<IActionResult> GetTeacherSubjectByIdAsync([FromRoute] Guid teacherSubjectId)
        {
            // Fetch Teacher Details
            var teacher = await _teachersSubjectServices.GetByIdAsync(teacherSubjectId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherSubjectDTO>(teacher));
        }

        [HttpPut]
        [Route("{teacherSubjectId:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid teacherSubjectId, [FromBody] TeacherSubjectDTO request)
        {
            if (await _teachersSubjectServices.Exists(teacherSubjectId))
            {
                // Update Details
                var updatedTeacher = await _teachersSubjectServices.Update(teacherSubjectId, _mapper.Map<TeacherSubject>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<TeacherSubjectDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{teacherSubjectId:guid}")]
        public async Task<IActionResult> DeleteTeachersAsync([FromRoute] Guid teacherSubjectId)
        {
            if (await _teachersSubjectServices.Exists(teacherSubjectId))
            {
                var teacher = await _teachersSubjectServices.Delete(teacherSubjectId);
                return Ok(_mapper.Map<TeacherSubjectDTO>(teacher));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] TeacherSubjectDTO request)
        {
            var teacher = await _teachersSubjectServices.Add(_mapper.Map<TeacherSubject>(request));
            if(teacher != null)
            return CreatedAtAction(nameof(GetTeacherSubjectByIdAsync), new { teacherSubjectId = teacher.Id },
                _mapper.Map<TeacherSubjectDTO>(teacher));
            return BadRequest();
        }
    }
}
