using System.ComponentModel.DataAnnotations;

namespace Core.Entities.DataModels
{
    public class ClassDetail:BaseTable
    {
        //[Key]
        //public Guid Id { get; set; }
        public required string ClassName { get; set; }
        public bool Status { get; set; }
    }
}
