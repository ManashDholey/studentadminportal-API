﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studentadminportal_API.DataModels;

#nullable disable

namespace studentadminportal_API.Migrations
{
    [DbContext(typeof(StudentAdminContext))]
    [Migration("20240718062118_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("studentadminportal_API.DataModels.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.ClassDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ClassDetails");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("OutOfMarks")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalMarks")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ChargeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Fees", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("FeeAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RollNo")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("GenderId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.StudentAttendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentAttendances");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Subject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.HasIndex("ClassDetailId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("GenderId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.TeacherAttendance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherAttendances");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.TeacherSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Address", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.Student", null)
                        .WithOne("Address")
                        .HasForeignKey("studentadminportal_API.DataModels.Address", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Exam", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("studentadminportal_API.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("studentadminportal_API.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Expense", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("studentadminportal_API.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Fees", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.Navigation("ClassDetail");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Student", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("studentadminportal_API.DataModels.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.StudentAttendance", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("studentadminportal_API.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("studentadminportal_API.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Subject", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassDetail");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Teacher", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("studentadminportal_API.DataModels.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("Address");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.TeacherAttendance", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.TeacherSubject", b =>
                {
                    b.HasOne("studentadminportal_API.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("studentadminportal_API.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("studentadminportal_API.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("studentadminportal_API.DataModels.Student", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
