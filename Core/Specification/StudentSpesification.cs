using Core.Entities.DataModels;


namespace Core.Specification
{
    public  class StudentSpesification : Specification<Student>
    {
        public StudentSpesification(string email):base(e => e.Email == email)
        {
            AddInclude(e => e.Gender);
            AddInclude(e => e.Address);
        }
    }
}
