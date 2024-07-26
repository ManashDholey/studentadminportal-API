using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.DataModels
{
    public class Subject:BaseTable
    {
        //public Guid SubjectId { get; set; }
        public required string  SubjectName { get; set; }
        [ForeignKey("ClassDetail")]
        public Guid ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public bool Status { get; set; }
    }
}
