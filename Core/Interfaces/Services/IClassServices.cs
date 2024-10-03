using Core.Entities.DataModels;
using Core.Specification;


namespace Core.Interfaces.Services
{
    public interface IClassServices
    {
        Task<IReadOnlyList<ClassDetail>> GetClassAsync();
        Task<ClassDetail> GetClassAsync(Guid classId);
        Task<bool> Exists(Guid classId);
        Task<ClassDetail> UpdateClass(Guid classId, ClassDetail request);
        Task<ClassDetail> DeleteClass(Guid classId);
        Task<ClassDetail> AddClass(ClassDetail request);
        Task<IReadOnlyList<ClassDetail>> GetClassWithSpecAsync(ClassSpecificationWithSpecParams spec);
        Task<int> GetClassCountAsync(ClassCountSpecificationWithSpecParams countSpec);
    }
}
