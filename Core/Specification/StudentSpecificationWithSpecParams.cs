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

            if (!string.IsNullOrEmpty(specParams.Active) && !string.IsNullOrEmpty(specParams.Direction))
            {
                switch (specParams.Active.ToLower())
                {
                    case "firstname":
                        {
                            switch (specParams.Direction?.ToLower())
                            {
                                case "asc":
                                    AddOrderBy(p => p.FirstName);
                                    break;
                                case "desc":
                                    AddOrderByDescending(p => p.FirstName);
                                    break;
                                default:
                                    AddOrderBy(n => n.FirstName);
                                    break;
                            }
                            break;
                        }
                    case "lastname":
                        {
                            switch (specParams.Direction.ToLower())
                            {
                                case "asc":
                                    AddOrderBy(p => p.LastName);
                                    break;
                                case "desc":
                                    AddOrderByDescending(p => p.LastName);
                                    break;
                                // blah..
                                default:
                                    AddOrderBy(n => n.LastName);
                                    break;
                            }
                            break;
                        }
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
