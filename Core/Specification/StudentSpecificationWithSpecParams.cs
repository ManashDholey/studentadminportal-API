using Core.Entities.DataModels;

namespace Core.Specification
{
    public class StudentSpecificationWithSpecParams : Specification<Student>
    {
        public StudentSpecificationWithSpecParams(StudentSpecParams specParams) : base(x => (string.IsNullOrEmpty(specParams.Search) || x.FirstName.ToLower().Contains(specParams.Search))
        && (!specParams.GenderId.HasValue || x.GenderId == specParams.GenderId)
        )
        {
            AddInclude(x => x.Gender);
            AddInclude(x => x.Address);
            AddOrderBy(x => x.FirstName);
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1),
                specParams.PageSize);

            if (!string.IsNullOrEmpty(specParams.Sort))
            {
                switch (specParams.Sort)
                {
                    case "rollNoAsc":
                        AddOrderBy(p => p.RollNo);
                        break;
                    case "rollNoDesc":
                        AddOrderByDescending(p => p.RollNo);
                        break;
                    case "emailAsc":
                        AddOrderBy(p => p.Email);
                        break;
                    case "emailDesc":
                        AddOrderByDescending(p => p.Email);
                        break;
                    default:
                        AddOrderBy(n => n.FirstName);
                        break;
                }
            }
        }
        public StudentSpecificationWithSpecParams( Guid Id): base(e => e.Id == Id)
        {
            AddInclude(x => x.Gender);
            AddInclude(x => x.Address);
        }
        
    }
}
