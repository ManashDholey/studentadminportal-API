﻿namespace studentadminportal_API.DataModels
{
    public class Teacher : BaseTable
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
        public Gender? Gender { get; set; }
        public Address? Address { get; set; }
    }
}
