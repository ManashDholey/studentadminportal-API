using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.DataModels
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
