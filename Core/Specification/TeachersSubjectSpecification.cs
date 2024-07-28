using Core.Entities.DataModels;

namespace Core.Specification
{
    public class TeachersSubjectSpecification : Specification<TeacherSubject>
    {
        public TeachersSubjectSpecification(Guid? classId, Guid? subjectId, Guid? teacherId):base(e=> e.ClassDetailId == classId 
        && e.SubjectId == subjectId 
        && e.TeacherId == teacherId)
        {
            
        }
        public TeachersSubjectSpecification()
        {
            AddInclude(o => o.ClassDetail!);
            AddInclude(o => o.Subject!);
            AddInclude(o => o.Teacher!);
        }
    }
}
