using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class TeacherSubjectDTO:BaseTableDTO
    {
        public Guid? ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public SubjectDTO? Subject { get; set; }
        public Guid? TeacherId { get; set; }
        public TeacherDTO? Teacher { get; set; }
    }
}
