namespace studentadminportal_API.DomainModels
{
    public class ClassDetailDTO: BaseTableDTO
    {
        public required string ClassName { get; set; }
        public bool Status { get; set; }
    }
}
