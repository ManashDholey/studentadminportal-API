
using Core.Entities.DataModels;

namespace Core.Specification
{
    public class ClassSpecificationWithSpecParams : Specification<ClassDetail>
    {
        public ClassSpecificationWithSpecParams(ClassSpecParams specParams) : base(x => string.IsNullOrEmpty(specParams.Search) || x.ClassName.ToLower().Contains(specParams.Search))
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1),
                specParams.PageSize);
            if (!string.IsNullOrEmpty(specParams.Active) && !string.IsNullOrEmpty(specParams.Direction))
            {
                switch (specParams.Active.ToLower())
                {
                    case "classname":
                        {
                            switch (specParams.Direction?.ToLower())
                            {
                                case "asc":
                                    AddOrderBy(p => p.ClassName);
                                    break;
                                case "desc":
                                    AddOrderByDescending(p => p.ClassName);
                                    break;
                                default:
                                    AddOrderBy(n => n.ClassName);
                                    break;
                            }
                            break;
                        }
                    default:
                        AddOrderBy(n => n.ClassName);
                        break;
                }
            }
        }
    }
}
