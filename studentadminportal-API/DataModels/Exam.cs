namespace studentadminportal_API.DataModels
{
    public class Exam:BaseTable
    {
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal OutOfMarks { get; set; }
    }
}
