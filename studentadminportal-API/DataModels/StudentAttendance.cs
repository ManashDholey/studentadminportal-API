using System.ComponentModel.DataAnnotations.Schema;

namespace studentadminportal_API.DataModels
{
    public class StudentAttendance:BaseTable
    {
        [ForeignKey("ClassDetail")]
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public Guid? StudentId { get; set; }
        public Student? Student { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
