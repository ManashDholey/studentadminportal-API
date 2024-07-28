using Core.Entities.DataModels;

namespace Core.Interfaces.Services
{
    public  interface IExpenseServices
    {
        Task<IReadOnlyList<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(Guid Id);
        Task<bool> Exists(Guid Id);
        Task<Expense> Update(Guid Id, Expense request);
        Task<Expense> Delete(Guid Id);
        Task<Expense> Add(Expense request);

    }
}
