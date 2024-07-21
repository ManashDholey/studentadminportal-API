using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace studentadminportal_API.DataModels
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options) : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ClassDetail> ClassDetails { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherAttendance> TeacherAttendances { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Fees> Fees { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
