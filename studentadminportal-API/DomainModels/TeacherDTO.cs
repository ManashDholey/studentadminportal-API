using studentadminportal_API.DataModels;

namespace studentadminportal_API.DomainModels
{
    public class TeacherDTO:BaseTableDTO
    {
        public required string TeacherCode { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Email { get; set; }
        public long Mobile { get; set; }
        public string? ProfileImageUrl { get; set; }
        public Guid? GenderId { get; set; }
        // Navigation Properties
        public GenderDTO? Gender { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
