using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class ExamDTO: BaseTableDTO
    {
        public Guid? ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public SubjectDTO? Subject { get; set; }
        public Guid? StudentId { get; set; }
        public StudentDTO? Student { get; set; }
        public decimal TotalMarks { get; set; }
        public decimal OutOfMarks { get; set; }
    }
}
