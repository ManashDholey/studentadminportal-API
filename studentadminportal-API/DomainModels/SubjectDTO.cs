using studentadminportal_API.DataModels;
namespace studentadminportal_API.DomainModels
{
    public class SubjectDTO : BaseTableDTO
    {
        //public Guid SubjectId { get; set; }
        public required string SubjectName { get; set; }
        public Guid ClassDetailId { get; set; }
        public ClassDetailDTO? ClassDetail { get; set; }
        public bool Status { get; set; }
    }
}
