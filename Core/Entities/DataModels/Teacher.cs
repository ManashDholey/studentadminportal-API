using Core.Entities.Identity;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities.DataModels
{
    public class Teacher : BaseTable
    {
        [MaxLength(20)]
        public required string TeacherCode { get; set; }
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [MaxLength(250)]
        public required string Email { get; set; }
        public long Mobile { get; set; }
        [MaxLength(250)]
        public string? ProfileImageUrl { get; set; }
        public Guid? GenderId { get; set; }
        // Navigation Properties
        public Gender? Gender { get; set; }
        public Address? Address { get; set; }
        [MaxLength(450)]
        public string? UserId { get; set; }
    }
}
