using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public interface ITeachersAttendanceServices
    {
        Task<IReadOnlyList<TeacherAttendance>> GetAllAsync();
        Task<TeacherAttendance> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<TeacherAttendance> Update(Guid Id, TeacherAttendance request);
        Task<TeacherAttendance> Delete(Guid Id);
        Task<TeacherAttendance> Add(TeacherAttendance request);
    }
}
