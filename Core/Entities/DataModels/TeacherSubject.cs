using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace Core.Entities.DataModels
{
    public class TeacherSubject : BaseTable
    {
        [ForeignKey("ClassDetail")]
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public Guid? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
