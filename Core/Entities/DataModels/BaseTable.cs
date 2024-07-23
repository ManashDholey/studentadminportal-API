using System.ComponentModel.DataAnnotations;

namespace Core.Entities.DataModels
{
    public class BaseTable
    {
        [Key]
        public Guid Id { get; set; }
    }
}
