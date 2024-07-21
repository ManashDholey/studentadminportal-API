using System.ComponentModel.DataAnnotations;

namespace studentadminportal_API.DataModels
{
    public class BaseTable
    {
        [Key]
        public Guid Id { get; set; }
    }
}
