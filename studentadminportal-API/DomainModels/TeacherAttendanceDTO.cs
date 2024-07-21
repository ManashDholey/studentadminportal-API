using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class TeacherAttendanceDTO:BaseTableDTO
    {
        public Guid? TeacherId { get; set; }
        public TeacherDTO? Teacher { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
