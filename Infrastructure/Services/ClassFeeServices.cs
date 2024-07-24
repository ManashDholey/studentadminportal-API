using Azure.Core;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;


namespace Infrastructure.Services
{
    public class ClassFeeServices : IClassFeeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassFeeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Fees> AddClassFees(Fees request)
        {
            var spec = new ClassFeesSpecification(request.ClassDetailId);
            var classFeeData = await _unitOfWork.Repository<Fees>().GetEntityWithSpec(spec);
            if (classFeeData == null)
            {
                request.Id = Guid.NewGuid();
                var classDetail = await _unitOfWork.Repository<Fees>().Add(request);
                await _unitOfWork.Complete();
                return classDetail!;
            }
            return classFeeData;
        }

        public async Task<Fees> DeleteClassFees(Guid classFeeId)
        {
            var classFees = await GetClassFeesAsync(classFeeId);

            if (classFees != null)
            {
                // _context.ClassDetails.Remove(classDetails);
                // await _context.SaveChangesAsync();
                _unitOfWork.Repository<Fees>().Delete(classFees);
                await _unitOfWork.Complete();
                return classFees;
            }
            return null;
        }

        public async Task<bool> Exists(Guid classFeeId)
        {
            var data = await _unitOfWork.Repository<Fees>().GetByIdAsync(classFeeId);
            return data != null;
        }

        public async Task<IReadOnlyList<Fees>> GetClassFeesAsync()
        {
            var spec = new ClassFeesSpecification();
            return await _unitOfWork.Repository<Fees>().ListWithSpecAsync(spec);
        }

        public async Task<Fees> GetClassFeesAsync(Guid classFeeId)
        {
            var spec = new ClassFeesSpecification(classFeeId);
            return await _unitOfWork.Repository<Fees>().GetEntityWithSpec(spec);
        }

        public async Task<Fees> UpdateClassFees(Guid classFeeId, Fees request)
        {
            var existingClassFees = await GetClassFeesAsync(classFeeId);
            if (existingClassFees != null)
            {
                existingClassFees.ClassDetailId = request.ClassDetailId;
                existingClassFees.FeeAmount = request.FeeAmount;
                await _unitOfWork.Complete();
                // await _context.SaveChangesAsync();
                return existingClassFees;
            }
            return null;
        }
    }
}
