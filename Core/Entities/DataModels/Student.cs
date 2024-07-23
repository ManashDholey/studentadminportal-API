using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.DataModels
{
    public class Student: BaseTable
    {
        [MaxLength(20)]
        public required string RollNo { get; set; }
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public required string LastName { get; set; }
        public required DateTime DateOfBirth { get; set; }
        [MaxLength(200)]
        public required string Email { get; set; }
        public long Mobile { get; set; }
        [MaxLength(200)]
        public string? ProfileImageUrl { get; set; }
        public Guid? GenderId { get; set; }
        // Navigation Properties
        public Gender? Gender { get; set; }
        public Address? Address { get; set; }
        [ForeignKey("ClassDetail")]
        public Guid? ClassDetailId { get; set; }
        public ClassDetail? ClassDetail { get; set; }
    }
}
