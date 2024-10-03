using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;
using studentadminportal_API.Helpers;


namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ClassController : BaseApiController
    {
        private readonly IClassServices _classRepository;
        private readonly IMapper _mapper;

        public ClassController(IClassServices classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassAsync([FromQuery] ClassSpecParams classSpec)
        {
            var spec = new ClassSpecificationWithSpecParams(classSpec);
            var countSpec = new ClassCountSpecificationWithSpecParams(classSpec);
            var count = await _classRepository.GetClassCountAsync(countSpec);
            var classDetails = await _classRepository.GetClassWithSpecAsync(spec);
            var data = _mapper.Map<List<ClassDetailDTO>>(classDetails);
            return Ok(new Pagination<ClassDetailDTO>(classSpec.PageIndex,
                classSpec.PageSize, count, data));
        }

        [HttpGet]
        [Route("{classId:guid}"), ActionName("GetClassAsync")]
        public async Task<IActionResult> GetClassAsync([FromRoute] Guid classId)
        {
            // Fetch Student Details
            var classDetails = await _classRepository.GetClassAsync(classId);

            // Return Student
            if (classDetails == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClassDetailDTO>(classDetails));
        }

        [HttpPut]
        [Route("{classId:guid}")]
        public async Task<IActionResult> UpdateClassAsync([FromRoute] Guid classId, [FromBody] ClassDetailDTO request)
        {
            if (await _classRepository.Exists(classId))
            {
                // Update Details
                var updatedClass = await _classRepository.UpdateClass(classId, _mapper.Map<ClassDetail>(request));

                if (updatedClass != null)
                {
                    return Ok(_mapper.Map<ClassDetailDTO>(updatedClass));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{classId:guid}")]
        public async Task<IActionResult> DeleteClassAsync([FromRoute] Guid classId)
        {
            if (await _classRepository.Exists(classId))
            {
                var classDetail = await _classRepository.DeleteClass(classId);
                return Ok(_mapper.Map<ClassDetailDTO>(classDetail));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddClassAsync([FromBody] ClassDetailDTO request)
        {
            var classDetails = await _classRepository.AddClass(_mapper.Map<ClassDetail>(request));
            return CreatedAtAction(nameof(GetClassAsync), new { classId = classDetails.Id },
                _mapper.Map<ClassDetailDTO>(classDetails));
        }



    }
}
