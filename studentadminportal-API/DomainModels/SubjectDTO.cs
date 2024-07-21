using studentadminportal_API.DataModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace studentadminportal_API.DomainModels
{
    public class SubjectDTO 
    {
        public Guid SubjectId { get; set; }
        public required string SubjectName { get; set; }
        [ForeignKey("ClassDetail")]
        public Guid ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public bool Status { get; set; }
    }
}
