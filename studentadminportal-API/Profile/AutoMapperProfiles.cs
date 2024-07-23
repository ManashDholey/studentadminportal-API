using studentadminportal_API.DomainModels;
using studentadminportal_API.Profile.AfterMaps;
using AutoMapper;
using DataModel = studentadminportal_API.DataModels;
using Core.Entities.DataModels;
namespace studentadminportal_API.Profile
{
    public class AutoMapperProfiles : AutoMapper.Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDTO>()
                .ReverseMap();

            CreateMap<Gender, GenderDTO>()
                .ReverseMap();

            CreateMap<Address, AddressDTO>()
                .ReverseMap();

            CreateMap<UpdateStudentRequest,Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();

            CreateMap<AddStudentRequest,Student>()
                .AfterMap<AddStudentRequestAfterMap>();
            CreateMap<ClassDetail, ClassDetailDTO>()
                .ReverseMap();

            CreateMap<Exam, ExamDTO>()
                .ReverseMap();

            CreateMap<Expense, ExpenseDTO>()
                .ReverseMap();
            CreateMap<Fees, FeesDTO>()
                .ReverseMap();

            CreateMap<Subject, SubjectDTO>()
                .ReverseMap();

            CreateMap<Teacher, TeacherDTO>()
                .ReverseMap();
            CreateMap<TeacherAttendance, TeacherAttendanceDTO>()
                .ReverseMap();

            CreateMap<TeacherSubject, TeacherSubjectDTO>()
                .ReverseMap();

            CreateMap<StudentAttendance, StudentAttendanceDTO>()
                .ReverseMap();
        }
    }
}
