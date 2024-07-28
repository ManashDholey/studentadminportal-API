using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public interface IStudentsAttendanceServices
    {
        Task<IReadOnlyList<StudentAttendance>> GetAllAsync();
        Task<StudentAttendance> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<StudentAttendance> Update(Guid Id, StudentAttendance request);
        Task<StudentAttendance> Delete(Guid Id);
        Task<StudentAttendance> Add(StudentAttendance request);
    }
}
