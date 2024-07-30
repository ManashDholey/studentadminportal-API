﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studentadminportal_API.DataModels;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(StudentAdminContext))]
    [Migration("20240730062135_UserRemoveProMrigration")]
    partial class UserRemoveProMrigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.DataModels.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhysicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasFilter("[StudentId] IS NOT NULL");

                    b.HasIndex("TeacherId")
                        .IsUnique()
                        .HasFilter("[TeacherId] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Core.Entities.DataModels.ClassDetail", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Exam", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Expense", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Fees", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Gender", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Student", b =>
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
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RollNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("GenderId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Core.Entities.DataModels.StudentAttendance", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("GenderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("Mobile")
                        .HasColumnType("bigint");

                    b.Property<string>("ProfileImageUrl")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TeacherCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Core.Entities.DataModels.TeacherAttendance", b =>
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

            modelBuilder.Entity("Core.Entities.DataModels.TeacherSubject", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClassDetailId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Address", b =>
                {
                    b.HasOne("Core.Entities.DataModels.Student", null)
                        .WithOne("Address")
                        .HasForeignKey("Core.Entities.DataModels.Address", "StudentId");

                    b.HasOne("Core.Entities.DataModels.Teacher", null)
                        .WithOne("Address")
                        .HasForeignKey("Core.Entities.DataModels.Address", "TeacherId");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Exam", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("Core.Entities.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Core.Entities.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Expense", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("Core.Entities.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Fees", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.Navigation("ClassDetail");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Student", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("Core.Entities.DataModels.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Core.Entities.DataModels.StudentAttendance", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("Core.Entities.DataModels.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("Core.Entities.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Subject", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassDetail");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Teacher", b =>
                {
                    b.HasOne("Core.Entities.DataModels.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("Core.Entities.DataModels.TeacherAttendance", b =>
                {
                    b.HasOne("Core.Entities.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Core.Entities.DataModels.TeacherSubject", b =>
                {
                    b.HasOne("Core.Entities.DataModels.ClassDetail", "ClassDetail")
                        .WithMany()
                        .HasForeignKey("ClassDetailId");

                    b.HasOne("Core.Entities.DataModels.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("Core.Entities.DataModels.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("ClassDetail");

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Student", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Core.Entities.DataModels.Teacher", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
