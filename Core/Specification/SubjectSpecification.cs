using Core.Entities.DataModels;


namespace Core.Specification
{
    public class SubjectSpecification:Specification<Subject>
    {
        public SubjectSpecification(Guid Id,Guid ClassDetailsId):base(equals=> equals.Id == Id && equals.ClassDetailId == ClassDetailsId)
        {
            AddInclude(o => o.ClassDetail!);
        }
        public SubjectSpecification(Guid? ClassDetailsId) : base(equals =>  equals.ClassDetailId == ClassDetailsId)
        {
            AddInclude(o => o.ClassDetail!);
        }
        public SubjectSpecification(Guid Id) : base(e => e.Id == Id)
        {
            AddInclude(o => o.ClassDetail!);
        }
        public SubjectSpecification()
        {
            AddInclude(o => o.ClassDetail!);
        }
    }
}
