using Core.Entities.DataModels;

namespace Core.Specification
{
    public  class ExpenseSpecification:Specification<Expense>
    {
        public ExpenseSpecification(Guid? classId, Guid? subjectId ):base(e=> e.ClassDetailId == classId && e.SubjectId == subjectId )
        {
            
        }
    }
}
