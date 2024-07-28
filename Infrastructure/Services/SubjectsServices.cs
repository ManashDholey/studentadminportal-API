using Azure.Core;
using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;
using Infrastructure.Data.Unit;

namespace Infrastructure.Services
{
    public class SubjectsServices : ISubjectsServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubjectsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  async Task<Subject> Add(Subject request)
        {
            SubjectSpecification subjectSpecification = new SubjectSpecification(request.Id, request.ClassDetailId);
            var subjectData = await _unitOfWork.Repository<Subject>().GetEntityWithSpec(subjectSpecification);
            if (subjectData == null)
            {
                var data = await _unitOfWork.Repository<Subject>().Add(request);
                await _unitOfWork.Complete();
                return data;
            }
            return subjectData;
        }

        public async Task<Subject> Delete(Guid Id)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetByIdAsync(Id);

            if (subject != null)
            {
                _unitOfWork.Repository<Subject>().Delete(subject);
                await _unitOfWork.Complete();
                return subject;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<Subject>().GetByIdAsync(Id);
            return data != null;
        }

        public async Task<IReadOnlyList<Subject>> GetAllAsync()
        {
             var spec = new SubjectSpecification();
             return await _unitOfWork.Repository<Subject>().ListWithSpecAsync(spec);
        }

        public async Task<Subject> GetByIdAsync(Guid Id)
        {
            var spec = new SubjectSpecification(Id);
            return await _unitOfWork.Repository<Subject>().GetEntityWithSpec(spec);
        }
        public async Task<IReadOnlyList<Subject>> GetByClassIdAsync(Guid? ClassDetailsId)
        {
            var spec = new SubjectSpecification(ClassDetailsId);
            return await _unitOfWork.Repository<Subject>().ListWithSpecAsync(spec);
        }
        public async Task<Subject> Update(Guid Id, Subject request)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetByIdAsync(Id);

            if (subject != null)
            {
                subject.Status = request.Status;
                subject.SubjectName = request.SubjectName;
                subject.ClassDetailId = request.ClassDetailId;
                await _unitOfWork.Complete();
                return subject;
            }
            return null;
        }
    }
}
