using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public  interface IStudentServices
    {
        Task<IReadOnlyList<Student>> GetStudentsAsync();
        Task<Student> GetStudentAsync(Guid studentId);
        Task<IReadOnlyList<Gender>> GetGendersAsync();
        Task<bool> Exists(Guid studentId);
        Task<Student> UpdateStudent(Guid studentId, Student request);
        Task<Student> DeleteStudent(Guid studentId);
        Task<Student> AddStudent(Student request);
        Task<bool> UpdateProfileImage(Guid studentId, string profileImageUrl);
    }
}
