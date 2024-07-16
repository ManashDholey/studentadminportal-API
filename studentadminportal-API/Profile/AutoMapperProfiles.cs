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
            CreateMap<DataModel.Student, Student>()
                .ReverseMap();

            CreateMap<DataModel.Gender, Gender>()
                .ReverseMap();

            CreateMap<DataModel.Address, Address>()
                .ReverseMap();

            CreateMap<UpdateStudentRequest,DataModel.Student>()
                .AfterMap<UpdateStudentRequestAfterMap>();

            CreateMap<AddStudentRequest,DataModel.Student>()
                .AfterMap<AddStudentRequestAfterMap>();
        }
    }
}
