using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Core.Specification;
using Infrastructure.Data.Unit;
using System.Runtime.InteropServices;


namespace Infrastructure.Services
{
    public class TeachersSubjectServices : ITeachersSubjectServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersSubjectServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TeacherSubject> Add(TeacherSubject request)
        {
            var spec = new TeachersSubjectSpecification(request.ClassDetailId, request.SubjectId, request.TeacherId);
             var data = await _unitOfWork.Repository<TeacherSubject>().GetEntityWithSpec(spec);
            if (data == null)
            {
                var subjectTeacher = await _unitOfWork.Repository<TeacherSubject>().Add(request);
                await _unitOfWork.Complete();
                return subjectTeacher;
            }
            return null;
        }

        public async Task<TeacherSubject> Delete(Guid Id)
        {
            var teacherSub = await _unitOfWork.Repository<TeacherSubject>().GetByIdAsync(Id);

            if (teacherSub != null)
            {
                _unitOfWork.Repository<TeacherSubject>().Delete(teacherSub);
                await _unitOfWork.Complete();
                return teacherSub;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<TeacherSubject>().GetByIdAsync(Id);
            return data != null;
        }

        public async Task<IReadOnlyList<TeacherSubject>> GetAllAsync()
        {
            var spec = new TeachersSubjectSpecification();
            return await _unitOfWork.Repository<TeacherSubject>().ListWithSpecAsync(spec);
        }

        public async Task<TeacherSubject> GetByIdAsync(Guid Id)
        {
            return await _unitOfWork.Repository<TeacherSubject>().GetByIdAsync(Id);
        }

        public async Task<TeacherSubject> Update(Guid Id, TeacherSubject request)
        {
            var teacher = await _unitOfWork.Repository<TeacherSubject>().GetByIdAsync(Id);

            if (teacher != null)
            {
                teacher.SubjectId = request.SubjectId;
                teacher.TeacherId = request.TeacherId;
                teacher.ClassDetailId = request.ClassDetailId;
                teacher.UpdateDate = DateTime.Now;
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }
    }
}
