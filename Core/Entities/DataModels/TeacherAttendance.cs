namespace Core.Entities.DataModels
{
    public class TeacherAttendance:BaseTable
    {
        public Guid?  TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
