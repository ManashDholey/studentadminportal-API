using Core.Entities.DataModels;


namespace Core.Specification
{
    public class ClassFeesSpecification : Specification<Fees>
    {
        public ClassFeesSpecification(Guid? ClassDetaolsId) : base(e => e.ClassDetailId == ClassDetaolsId)
        {
            AddInclude(o => o.ClassDetail!);
        }
        public ClassFeesSpecification(Guid ClassFeesid) :base(e => e.Id == ClassFeesid) 
        {
            AddInclude(o => o.ClassDetail!);
        }
        public ClassFeesSpecification()
        {
            AddInclude(o => o.ClassDetail!);
        }
    }
}
