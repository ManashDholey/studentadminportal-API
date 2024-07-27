using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;
using Infrastructure.Data.Unit;

namespace Infrastructure.Services
{
    public class TeachersServices : ITeachersServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Teacher> AddTeacher(Teacher request)
        {
            var spec = new TeacherSpecification(request.Email);
            var teacher = await _unitOfWork.Repository<Teacher>().GetEntityWithSpec(spec);
            if (teacher == null)
            {
                var data = await _unitOfWork.Repository<Teacher>().Add(request);
                await _unitOfWork.Complete();
                return data;
            }
            return teacher;
        }

        public async Task<Teacher> DeleteTeacher(Guid Id)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);

            if (teacher != null)
            {
                _unitOfWork.Repository<Teacher>().Delete(teacher);
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);
            return data != null;
        }

        public async Task<Teacher> GetTeacherByIdAsync(Guid Id)
        {
            return await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);
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
        public async Task<IReadOnlyList<Teacher>> GetTeachersAsync()
        {
            return await _unitOfWork.Repository<Teacher>().GetAllAsync();
        }

        public async Task<Teacher> UpdateTeacher(Guid Id, Teacher request)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetByIdAsync(Id);

            if (teacher != null)
            {
                teacher.Address = request.Address;
                teacher.DateOfBirth = request.DateOfBirth;
                teacher.FirstName = request.FirstName;
                teacher.LastName = request.LastName;
                teacher.Email = request.Email;
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }
    }
}
