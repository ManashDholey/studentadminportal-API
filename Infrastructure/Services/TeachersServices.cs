using Azure.Core;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Response;
using Core.Specification;
using Infrastructure.Data.Unit;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace Infrastructure.Services
{
    public class TeachersServices : ITeachersServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<Teacher>> AddTeacher(Teacher request)
        {
            var response = new Response<Teacher>();
            var spec = new TeacherSpecification(request.Email);
            var teacher = await _unitOfWork.Repository<Teacher>().GetEntityWithSpec(spec);
            if (teacher == null)
            {
                var data = await _unitOfWork.Repository<Teacher>().Add(request);
                await _unitOfWork.Complete();
                response.Data = data;
                response.Success = true;
                response.ErrorMessage = string.Empty;
                return response;
            }
            response.Success = false;
            response.ErrorMessage = Messages.TeacherDataNotFound;
            response.Data = request;
            return response;
        }

        public async Task<Response<Teacher>> DeleteTeacher(Guid Id)
        {
            var response = new Response<Teacher>();
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);

            if (teacher != null)
            {
                _unitOfWork.Repository<Teacher>().Delete(teacher);
                await _unitOfWork.Complete();
                response.Success = true;
                response.ErrorMessage = string.Empty;
                response.Data = teacher;
                return response;
            }
            response.Success= false;
            response.ErrorMessage = Messages.TeacherDataNotFound;
            return response;
        }

        public async Task<Response<Teacher>> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);
            var response = new Response<Teacher>();
            response.Success = data != null; 
            response.ErrorMessage = string.Empty;
            response.Data = data;
            return response;
        }

        public async Task<Response<Teacher>> GetTeacherByIdAsync(Guid Id)
        {
            var data = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);
            var response = new Response<Teacher>();
            response.Success = data != null;
            response.Data = data;
            response.ErrorMessage = data != null ?Messages.TeacherDataFound : Messages.TeacherDataNotFound;
            return response;
        }
        public async Task<bool> UpdateProfileImage(Guid teacherId, string profileImageUrl)
        {
            
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(teacherId);

            if (teacher != null)
            {
                teacher.ProfileImageUrl = profileImageUrl;
                //await context.SaveChangesAsync();
                await _unitOfWork.Complete();
                return true;
            }
            return false;

        }
        public async Task<Response<IReadOnlyList<Teacher>>> GetTeachersAsync()
        {
            var spec = new TeacherSpecification();
            var data = await _unitOfWork.Repository<Teacher>().ListWithSpecAsync(spec);
            var response = new Response<IReadOnlyList<Teacher>>();
            response.Success = data != null;
            response.Data = data;
            response.ErrorMessage = data != null ? Messages.TeacherDataFound  : Messages.TeacherDataNotFound;
            return response;
        }

        public async Task<Response<Teacher>> UpdateTeacher(Guid Id, Teacher request)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);
            var response = new Response<Teacher>();
            if (teacher != null)
            {
                teacher.Address = request.Address;
                teacher.DateOfBirth = request.DateOfBirth;
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                teacher.Email = request.Email;
                await _unitOfWork.Complete();
                response.Success = true;
                response.ErrorMessage = Messages.TeacherDataUpdate;
                response.Data = teacher;
                return response;
            }
            response.Success = false;
            response.ErrorMessage = Messages.TeacherDataNotFound;
            return null;
        }
    }
}
