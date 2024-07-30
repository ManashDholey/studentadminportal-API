using Azure.Core;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;
using Infrastructure.Data.Unit;

namespace Infrastructure.Services
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExpenseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Expense> Add(Expense request)
        {
            var spec = new ExpenseSpecification(request.ClassDetailId, request.SubjectId);
            var data = await _unitOfWork.Repository<Expense>().GetEntityWithSpec(spec);
            if(data == null)
            {
                var expance = await _unitOfWork.Repository<Expense>().Add(request);
                await _unitOfWork.Complete();
                 return expance;
            }
            return data;
        }

        public async Task<Expense> Delete(Guid Id)
        {
            var data  = await _unitOfWork.Repository<Expense>().GetByIdAsync(Id);
            if (data != null){
                _unitOfWork.Repository<Expense>().Delete(data);
                await _unitOfWork.Complete();
                return data;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<Expense>().GetByIdAsync(Id);
            return data != null ? true : false;
        }

        public async Task<IReadOnlyList<Expense>> GetAllAsync()
        {
            var spec = new ExpenseSpecification();
            return await _unitOfWork.Repository<Expense>().ListWithSpecAsync(spec);
        }

        public async Task<Expense> GetByIdAsync(Guid Id)
        {
            var spec = new ExpenseSpecification(Id);
            return await _unitOfWork.Repository<Expense>().GetEntityWithSpec(spec);
        }

        public async Task<Expense> Update(Guid Id, Expense request)
        {
            var dataExpance = await _unitOfWork.Repository<Expense>().GetByIdAsync(Id);

            if (dataExpance != null)
            {
                dataExpance.SubjectId = request.SubjectId;
                dataExpance.ClassDetailId = request.ClassDetailId;
                dataExpance.ChargeAmount = request.ChargeAmount;
                await _unitOfWork.Complete();
                return dataExpance;
            }
            return null;
        }
    }
}
