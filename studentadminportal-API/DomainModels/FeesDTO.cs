using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class FeesDTO:BaseTableDTO
    {
        public Guid? ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public decimal FeeAmount { get; set; }
    }
}
