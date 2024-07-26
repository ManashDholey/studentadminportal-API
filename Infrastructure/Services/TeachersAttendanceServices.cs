using Core.Entities.DataModels;
using Core.Interfaces.Services;
using Core.Interfaces.Unit;
using Infrastructure.Data.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TeachersAttendanceServices : ITeachersAttendanceServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public TeachersAttendanceServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TeacherAttendance> Add(TeacherAttendance request)
        {
            var data = await _unitOfWork.Repository<TeacherAttendance>().Add(request);
            await _unitOfWork.Complete();
            return data;
        }

        public async Task<TeacherAttendance> Delete(Guid Id)
        {
            var teacher = await _unitOfWork.Repository<TeacherAttendance>().GetByIdAsync(Id);

            if (teacher != null)
            {
                _unitOfWork.Repository<TeacherAttendance>().Delete(teacher);
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }

        public async Task<bool> Exists(Guid Id)
        {
            var data = await _unitOfWork.Repository<TeacherAttendance>().GetByIdAsync(Id);
            return data != null;
        }

        public async Task<IReadOnlyList<TeacherAttendance>> GetAllAsync()
        {
            return await _unitOfWork.Repository<TeacherAttendance>().GetAllAsync();
        }

        public async Task<TeacherAttendance> GetByIdAsync(Guid Id)
        {
            return await _unitOfWork.Repository<TeacherAttendance>().GetByIdAsync(Id);
        }

        public async Task<TeacherAttendance> Update(Guid Id, TeacherAttendance request)
        {
            var teacher = await _unitOfWork.Repository<TeacherAttendance>().GetByIdAsync(Id);

            if (teacher != null)
            {
                teacher.TeacherId = request.TeacherId;
                teacher.UpdateDate = DateTime.Now;
                teacher.Status = request.Status;
                await _unitOfWork.Complete();
                return teacher;
            }
            return null;
        }
    }
}
