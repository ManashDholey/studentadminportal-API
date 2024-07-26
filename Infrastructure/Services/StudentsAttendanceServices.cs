using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;


namespace Infrastructure.Services
{
    public class StudentsAttendanceServices : IStudentsAttendanceServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentsAttendanceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<StudentAttendance> Add(StudentAttendance request)
        {
            var data =  await _unitOfWork.Repository<StudentAttendance>().Add(request);
            await _unitOfWork.Complete();
            return data;
        }

        public async Task<StudentAttendance> Delete(Guid Id)
        {
            var teacher = await _unitOfWork.Repository<StudentAttendance>().GetByIdAsync(Id);

            if (teacher != null)
            {
                _unitOfWork.Repository<StudentAttendance>().Delete(teacher);
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<StudentAttendance>().GetByIdAsync(Id);
            return data != null;
        }

        public async Task<IReadOnlyList<StudentAttendance>> GetAllAsync()
        {
            return await _unitOfWork.Repository<StudentAttendance>().GetAllAsync();
        }

        public async Task<StudentAttendance> GetByIdAsync(Guid Id)
        {
            return await _unitOfWork.Repository<StudentAttendance>().GetByIdAsync(Id);
        }

        public async Task<StudentAttendance> Update(Guid Id, StudentAttendance request)
        {
            var studentAttendance = await _unitOfWork.Repository<StudentAttendance>().GetByIdAsync(Id);

            if (studentAttendance != null)
            {
                studentAttendance.SubjectId = request.SubjectId;
                studentAttendance.UpdateDate = DateTime.Now;
                studentAttendance.ClassDetailId = request.ClassDetailId;
                studentAttendance.StudentId = request.StudentId;
                await _unitOfWork.Complete();
                return studentAttendance;
            }
            return null;
        }
    }
}
