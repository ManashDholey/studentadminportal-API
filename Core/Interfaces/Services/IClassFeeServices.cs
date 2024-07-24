using Core.Entities.DataModels;


namespace Core.Interfaces.Services
{
    public interface IClassFeeServices
    {
        Task<IReadOnlyList<Fees>> GetClassFeesAsync();
        Task<Fees> GetClassFeesAsync(Guid classId);
        Task<bool> Exists(Guid classId);
        Task<Fees> UpdateClassFees(Guid classId, Fees request);
        Task<Fees> DeleteClassFees(Guid classId);
        Task<Fees> AddClassFees(Fees request);
    }
}
