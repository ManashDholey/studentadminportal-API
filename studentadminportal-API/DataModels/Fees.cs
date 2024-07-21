using System.ComponentModel.DataAnnotations.Schema;

namespace studentadminportal_API.DataModels
{
    public class Fees:BaseTable
    {
        [ForeignKey("ClassDetail")]
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
        public decimal FeeAmount { get; set; }

    }
}
