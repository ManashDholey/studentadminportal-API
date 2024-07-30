using Core.Entities.DataModels;

namespace Core.Specification
{
    public  class ExpenseSpecification:Specification<Expense>
    {
        public ExpenseSpecification(Guid? classId, Guid? subjectId ):base(e=> e.ClassDetailId == classId && e.SubjectId == subjectId )
        {
        }
        public ExpenseSpecification(Guid Id):base(e=> e.Id == Id ) 
        {
            AddInclude(e => e.ClassDetail);
            AddInclude(e => e.Subject);
        }
        public ExpenseSpecification()
        {
            AddInclude(e => e.ClassDetail);
            AddInclude(e => e.Subject);
        }
    }
}
