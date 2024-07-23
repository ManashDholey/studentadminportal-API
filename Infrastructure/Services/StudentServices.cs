using Azure.Core;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;


namespace Infrastructure.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Student> AddStudent(Student request)
        {
           var studentData = await _unitOfWork.Repository<Student>().Add(request);
            await _unitOfWork.Complete();
            return studentData!;

        }

        public async Task<Student> DeleteStudent(Guid studentId)
        {
           // var student = await GetStudentAsync(studentId);
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);

            if (student != null)
            {
                _unitOfWork.Repository<Student>().Delete(student);
                //context.Student.Remove(student);
                //await context.SaveChangesAsync();
               await _unitOfWork.Complete();
                return student;
            }
            return null;
        }

        public async Task<bool> Exists(Guid studentId)
        {
           // return await context.Student.AnyAsync(x => x.Id == studentId);
            var data =  await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);
           return data != null ? true : false;
        }

        public async Task<IReadOnlyList<Gender>> GetGendersAsync()
        {
           // return await context.Gender.ToListAsync();
           return await _unitOfWork.Repository<Gender>().GetAllAsync();
        }

        public async Task<Student> GetStudentAsync(Guid studentId)
        {
           return await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);
        }

        public async Task<IReadOnlyList<Student>> GetStudentsAsync()
        {
            var studentSpec = new ProductSpecification();
            return await _unitOfWork.Repository<Student>().ListAsync(studentSpec);
        }

        public async Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl)
        {
            //var student = await GetStudentAsync(studentId);
            var student = await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);

            if (student != null)
            {
                student.ProfileImageUrl = profileImageUrl;
                //await context.SaveChangesAsync();
                await _unitOfWork.Complete();
                return true;
            }
            return false;

        }

        public async Task<Student> UpdateStudent(Guid studentId, Student request)
        {
            //var existingStudent = await GetStudentAsync(studentId);
             var existingStudent = await _unitOfWork.Repository<Student>().GetByIdAsync(studentId);
            if (existingStudent != null)
            {
                existingStudent.FirstName = request.FirstName;
                existingStudent.LastName = request.LastName;
                existingStudent.DateOfBirth = request.DateOfBirth;
                existingStudent.Email = request.Email;
                existingStudent.Mobile = request.Mobile;
                existingStudent.GenderId = request.GenderId;
                existingStudent.Address!.PostalAddress = request.Address!.PostalAddress;

                //await context.SaveChangesAsync();
                await _unitOfWork.Complete();
                return existingStudent;
            }

            return null;
        }
    }
}
