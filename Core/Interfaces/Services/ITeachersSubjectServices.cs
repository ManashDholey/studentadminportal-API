using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public interface ITeachersSubjectServices
    {
        Task<IReadOnlyList<TeacherSubject>> GetAllAsync();
        Task<TeacherSubject> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<TeacherSubject> Update(Guid Id, TeacherSubject request);
        Task<TeacherSubject> Delete(Guid Id);
        Task<TeacherSubject> Add(TeacherSubject request);
    }
}
