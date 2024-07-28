using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public interface ISubjectsServices
    {
        Task<IReadOnlyList<Subject>> GetAllAsync();
        Task<Subject> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<Subject> Update(Guid Id, Subject request);
        Task<Subject> Delete(Guid Id);
        Task<Subject> Add(Subject request);
        Task<IReadOnlyList<Subject>> GetByClassIdAsync(Guid? ClassDetailsId);
    }
}
