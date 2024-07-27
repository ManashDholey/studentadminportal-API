using Core.Entities.DataModels;
using Core.Response;


namespace Core.Interfaces.Services
{
    public  interface ITeachersServices
    {
        Task<Response<IReadOnlyList<Teacher>>> GetTeachersAsync();
        Task<Response<Teacher>> GetTeacherByIdAsync(Guid Id);
        Task<Response<Teacher>> Exists(Guid Id);
        Task<Response<Teacher>> UpdateTeacher(Guid Id, Teacher request);
        Task<Response<Teacher>> DeleteTeacher(Guid Id);
        Task<Response<Teacher>> AddTeacher(Teacher request);
        Task<bool> UpdateProfileImage(Guid teacherId, string profileImageUrl);
    }
}
