using studentadminportal_API.DomainModels;
using studentadminportal_API.Profile.AfterMaps;
using AutoMapper;
using DataModel = studentadminportal_API.DataModels;
namespace studentadminportal_API.Profile
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<DataModel.Student, StudentDTO>()
                .ReverseMap();

            CreateMap<DataModel.Gender, GenderDTO>()
                .ReverseMap();

            CreateMap<DataModel.Address, AddressDTO>()
                .ReverseMap();

            CreateMap<UpdateStudentRequest,DataModel.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();

            CreateMap<AddStudentRequest,DataModel.Student>()
                .AfterMap<AddStudentRequestAfterMap>();
            CreateMap<DataModel.ClassDetail, ClassDetailDTO>()
                .ReverseMap();

            CreateMap<DataModel.Exam, ExamDTO>()
                .ReverseMap();

            CreateMap<DataModel.Expense, ExpenseDTO>()
                .ReverseMap();
            CreateMap<DataModel.Fees, FeesDTO>()
                .ReverseMap();

            CreateMap<DataModel.Subject, SubjectDTO>()
                .ReverseMap();

            CreateMap<DataModel.Teacher, TeacherDTO>()
                .ReverseMap();
            CreateMap<DataModel.TeacherAttendance, TeacherAttendanceDTO>()
                .ReverseMap();

            CreateMap<DataModel.TeacherSubject, TeacherSubjectDTO>()
                .ReverseMap();

            CreateMap<DataModel.StudentAttendance, StudentAttendanceDTO>()
                .ReverseMap();
        }
    }
}
