using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public  interface ITeachersServices
    {
        Task<IReadOnlyList<Teacher>> GetTeachersAsync();
        Task<Teacher> GetTeacherByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<Teacher> UpdateTeacher(Guid Id, Teacher request);
        Task<Teacher> DeleteTeacher(Guid Id);
        Task<Teacher> AddTeacher(Teacher request);
        Task<bool> UpdateProfileImage(Guid teacherId, string profileImageUrl);
    }
}
