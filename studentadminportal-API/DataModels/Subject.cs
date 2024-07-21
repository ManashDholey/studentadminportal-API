using System.ComponentModel.DataAnnotations.Schema;

namespace studentadminportal_API.DataModels
{
    public class Subject
    {
        public Guid SubjectId { get; set; }
        public required string  SubjectName { get; set; }
        [ForeignKey("ClassDetail")]
        public Guid ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public bool Status { get; set; }
    }
}
