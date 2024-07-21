using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class ExpenseDTO : BaseTableDTO
    {
        public Guid? ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public Guid? SubjectId { get; set; }
        public SubjectDTO? Subject { get; set; }
        public decimal ChargeAmount { get; set; }
    }
}
