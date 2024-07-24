using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Infrastructure.Data.Unit;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Services
{
    public class ClassServices: IClassServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassServices(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClassDetail> AddClass(ClassDetail request)
        {
            request.Id = Guid.NewGuid();
            var classDetail = await _unitOfWork.Repository<ClassDetail>().Add(request);
            await _unitOfWork.Complete();
            return classDetail!;
        }

        public async Task<ClassDetail> DeleteClass(Guid classId)
        {
            var classDetails = await GetClassAsync(classId);

            if (classDetails != null)
            {
                // _context.ClassDetails.Remove(classDetails);
                // await _context.SaveChangesAsync();
             _unitOfWork.Repository<ClassDetail>().Delete(classDetails);
             await  _unitOfWork.Complete();
                return classDetails;
            }
            return null;
        }

        public async Task<bool> Exists(Guid classId)
        {
            var data = await _unitOfWork.Repository<ClassDetail>().GetByIdAsync(classId);
            return data != null;
        }

        public async Task<IReadOnlyList<ClassDetail>> GetClassAsync()
        {
            return await _unitOfWork.Repository<ClassDetail>().GetAllAsync();
        }

        public async Task<ClassDetail> GetClassAsync(Guid classId)
        {
          //  return await _context.ClassDetails
              //  .FirstOrDefaultAsync(x => x.Id == classId);

            return await _unitOfWork.Repository<ClassDetail>().GetByIdAsync(classId);
        }

        public async Task<ClassDetail> UpdateClass(Guid classId, ClassDetail request)
        {
            var existingClass = await GetClassAsync(classId);
            if (existingClass != null)
            {
                existingClass.ClassName = request.ClassName;
                existingClass.Status = request.Status;
                await _unitOfWork.Complete();
               // await _context.SaveChangesAsync();
                return existingClass;
            }
            return null;
        }
    }
}
