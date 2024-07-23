using Core.Entities.DataModels;
using Core.Interfaces.Specification;


namespace Core.Specification
{
    public class ProductSpecification : Specification<Student>
    {
        public ProductSpecification() : base()
        {
            AddInclude(o => o.Gender!);
            AddInclude(o => o.Address!);
        }
    }
}
