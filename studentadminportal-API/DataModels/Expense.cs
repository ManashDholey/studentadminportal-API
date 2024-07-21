using System.ComponentModel.DataAnnotations.Schema;

namespace studentadminportal_API.DataModels
{
    public class Expense:BaseTable
    {
        [ForeignKey("ClassDetail")]
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public decimal ChargeAmount { get; set; }

    }
}
