
using Core.Entities.DataModels;

namespace Core.Specification
{
    public class StudentSpecificationCount : Specification<Student>
    {
        public StudentSpecificationCount(StudentSpecParams specParams) :base(x => (string.IsNullOrEmpty(specParams.Search) || x.FirstName.ToLower().Contains(specParams.Search))
        && (!specParams.GenderId.HasValue || x.GenderId == specParams.GenderId))
        {
        }
    }
}
