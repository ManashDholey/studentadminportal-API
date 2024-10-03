using Core.Entities.DataModels;

namespace Core.Specification
{
    public  class ClassCountSpecificationWithSpecParams : Specification<ClassDetail>
    {
        public ClassCountSpecificationWithSpecParams(ClassSpecParams specParams) :base(x => string.IsNullOrEmpty(specParams.Search) || x.ClassName.ToLower().Contains(specParams.Search))
        {
        }
    }
}
