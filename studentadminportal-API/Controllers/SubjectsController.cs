using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;

namespace studentadminportal_API.Controllers
{ 
    public class SubjectsController : BaseApiController
    {
        private readonly ISubjectsServices _subjectsServices;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectsServices subjectsServices, IMapper mapper)
        {
            _subjectsServices = subjectsServices;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teacher = await _subjectsServices.GetAllAsync();

            return Ok(_mapper.Map<IReadOnlyList<SubjectDTO>>(teacher));
        }

        [HttpGet]
        [Route("{Id:guid}"), ActionName("GetSubjectByIdAsync")]
        public async Task<IActionResult> GetSubjectByIdAsync([FromRoute] Guid Id)
        {
            // Fetch Teacher Details
            var teacher = await _subjectsServices.GetByIdAsync(Id);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SubjectDTO>(teacher));
        }
        [HttpGet]
        [Route("GetSubjectByClassIdAsync/{classId:guid}"), ActionName("GetSubjectByClassIdAsync")]
        public async Task<IActionResult> GetSubjectByClassIdAsync([FromRoute] Guid classId)
        {
            // Fetch Teacher Details
            var teacher = await _subjectsServices.GetByClassIdAsync(classId);

            // Return teacher
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IReadOnlyList<SubjectDTO>>(teacher));
        }

        [HttpPut]
        [Route("{Id:guid}")]
        public async Task<IActionResult> UpdatAsync([FromRoute] Guid Id, [FromBody] SubjectDTO request)
        {
            if (await _subjectsServices.Exists(Id))
            {
                // Update Details
                var updatedTeacher = await _subjectsServices.Update(Id, _mapper.Map<Subject>(request));

                if (updatedTeacher != null)
                {
                    return Ok(_mapper.Map<SubjectDTO>(updatedTeacher));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{Id:guid}")]
        public async Task<IActionResult> DeleteSubjectAsync([FromRoute] Guid Id)
        {
            if (await _subjectsServices.Exists(Id))
            {
                var teacher = await _subjectsServices.Delete(Id);
                return Ok(_mapper.Map<SubjectDTO>(teacher));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSubjectAsync([FromBody] SubjectDTO request)
        {
            var teacher = await _subjectsServices.Add(_mapper.Map<Subject>(request));
            return CreatedAtAction(nameof(GetSubjectByIdAsync), new { Id = teacher.Id },
                _mapper.Map<SubjectDTO>(teacher));
        }


    }
}
