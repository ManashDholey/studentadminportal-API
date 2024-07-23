using studentadminportal_API.DomainModels;
using AutoMapper;
using DataModel = studentadminportal_API.DataModels;
using Core.Entities.DataModels;
namespace studentadminportal_API.Profile.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequest, Student>
    {
        public void Process(UpdateStudentRequest source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address()
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
