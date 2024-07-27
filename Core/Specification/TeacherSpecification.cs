using Core.Entities.DataModels;


namespace Core.Specification
{
    public class TeacherSpecification:Specification<Teacher>
    {
        public TeacherSpecification(string email):base(e=> e.Email == email)
        {
            AddInclude(e => e.Gender);
            AddInclude(e => e.Address);
        }
    }
}
