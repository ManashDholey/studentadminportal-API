﻿using AutoMapper;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using studentadminportal_API.DomainModels;
using studentadminportal_API.FileServices.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;
using studentadminportal_API.Helpers;


namespace studentadminportal_API.Controllers
{
    
    public class StudentsController : BaseApiController
    {
        private readonly IStudentServices _studentRepository;
        private readonly IMapper _mapper;
        private readonly IImageRepository _imageRepository;

        public StudentsController(IStudentServices studentRepository, IMapper mapper,
            IImageRepository imageRepository)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _imageRepository = imageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync([FromQuery] StudentSpecParams specParams)
        {
            var spec = new StudentSpecificationWithSpecParams(specParams);
            var countSpec = new StudentSpecificationCount(specParams);
            var count = await _studentRepository.GetStudentsCountAsync(countSpec);
            var students = await _studentRepository.GetStudentsAsync(spec);
            var studentData = _mapper.Map<List<StudentDTO>>(students);

            return Ok(new Pagination<StudentDTO>(specParams.PageIndex,
                specParams.PageSize, count, studentData));
        }

        [HttpGet]
        [Route("{studentId:guid}"), ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync([FromRoute] Guid studentId)
        {
            // Fetch Student Details
            var student = await _studentRepository.GetStudentAsync(studentId);

            // Return Student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDTO>(student));
        }

        [HttpPut]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequest request)
        {
            if (await _studentRepository.Exists(studentId))
            {
                // Update Details
                var updatedStudent = await _studentRepository.UpdateStudent(studentId, _mapper.Map<Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<StudentDTO>(updatedStudent));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await _studentRepository.Exists(studentId))
            {
                var student = await _studentRepository.DeleteStudent(studentId);
                return Ok(_mapper.Map<StudentDTO>(student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] AddStudentRequest request)
        {
            var student = await _studentRepository.AddStudent(_mapper.Map<Student>(request));
            return CreatedAtAction(nameof(GetStudentAsync), new { studentId = student.Id },
                _mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        [Route("{studentId:guid}/upload-image")] //upload-image
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
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
                    if (await _studentRepository.Exists(studentId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                        var fileImagePath = await _imageRepository.Upload(profileImage, fileName);

                        if (await _studentRepository.UpdateProfileImage(studentId, fileImagePath))
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
