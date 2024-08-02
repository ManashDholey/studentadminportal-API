using Core.Entities.DataModels;
using Core.Specification;


namespace Core.Interfaces.Services
{
    public  interface IStudentServices
    {
        Task<IReadOnlyList<Student>> GetStudentsAsync();
        Task<IReadOnlyList<Student>> GetStudentsAsync(StudentSpecificationWithSpecParams spec);
        Task<int> GetStudentsCountAsync(StudentSpecificationCount spec);
        Task<Student> GetStudentAsync(Guid studentId);
        Task<IReadOnlyList<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
