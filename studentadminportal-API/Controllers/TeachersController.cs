using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;
using studentadminportal_API.FileServices.Interface;

namespace studentadminportal_API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TeachersController : BaseApiController
    {
        private readonly ITeachersServices _teachersServices;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public TeachersController(ITeachersServices teachersServices, IMapper mapper, IImageRepository imageRepository)
        {
            _teachersServices= teachersServices;
            _mapper = mapper;
            _imageRepository = imageRepository;
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
        [HttpPost]
        [Route("{teacherId:guid}/upload-image")] //upload-image
        public async Task<IActionResult> UploadImage([FromRoute] Guid teacherId, IFormFile profileImage)
        {
            var validExtensions = new List<string>
            {
               ".jpeg",
               ".png",
               ".gif",
               ".jpg"
            };

            if (profileImage != null && profileImage.Length > 0)
            {
                var extension = Path.GetExtension(profileImage.FileName);
                if (validExtensions.Contains(extension))
                {
                    if (await _teachersServices.Exists(teacherId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                        var fileImagePath = await _imageRepository.Upload(profileImage, fileName);

                        if (await _teachersServices.UpdateProfileImage(teacherId, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }

                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }

                return BadRequest("This is not a valid Image format");
            }
            return NotFound();
        }


    }
}
