﻿// <auto-generated />
using System;
using DemoAPI.Data.EF.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoAPI.Data.EF.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190708043626_Modify-DB")]
    partial class ModifyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Attendance", b =>
                {
                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("LectureId");

                    b.Property<bool>("IsAttendance");

                    b.HasKey("StudentId", "LectureId");

                    b.HasAlternateKey("LectureId", "StudentId");

                    b.ToTable("Attendance");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Course", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.CourseTeacher", b =>
                {
                    b.Property<Guid>("CourseId");

                    b.Property<Guid>("TeacherId");

                    b.Property<string>("EndDate")
                        .IsRequired();

                    b.Property<string>("StartDate")
                        .IsRequired();

                    b.HasKey("CourseId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("CourseTeacher");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Examination", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("ResponsibleTeacherId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("ResponsibleTeacherId");

                    b.ToTable("Examination");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Grade", b =>
                {
                    b.Property<Guid>("StudentId");

                    b.Property<Guid>("GradingTeacherId");

                    b.Property<Guid>("ExaminationId");

                    b.Property<byte>("StudentGrade");

                    b.HasKey("StudentId", "GradingTeacherId", "ExaminationId");

                    b.HasAlternateKey("ExaminationId", "GradingTeacherId", "StudentId");

                    b.HasIndex("GradingTeacherId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Room");

                    b.Property<Guid>("TeacherId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class")
                        .IsRequired();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("StudentName")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.StudentCourse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CourseId");

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<Guid>("StudentId");

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Teacher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("CreatedTime");

                    b.Property<int>("EntityStatus");

                    b.Property<string>("Mentor")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<DateTimeOffset>("UpdatedTime");

                    b.HasKey("Id");

                    b.ToTable("Teacher");
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Attendance", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Lecture", "Lecture")
                        .WithMany("Attendances")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Student", "Student")
                        .WithMany("Attendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.CourseTeacher", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Course", "Course")
                        .WithMany("CourseTeacher")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Teacher", "Teacher")
                        .WithMany("CourseTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Examination", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Course", "Course")
                        .WithMany("Examinations")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Teacher", "Teacher")
                        .WithMany("Examinations")
                        .HasForeignKey("ResponsibleTeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Grade", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Examination", "Examination")
                        .WithMany("Grades")
                        .HasForeignKey("ExaminationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Teacher", "Teacher")
                        .WithMany("Grades")
                        .HasForeignKey("GradingTeacherId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.Lecture", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Course", "Course")
                        .WithMany("Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Teacher", "Teacher")
                        .WithMany("Lectures")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DemoAPI.Data.Models.Database.StudentCourse", b =>
                {
                    b.HasOne("DemoAPI.Data.Models.Database.Course", "Course")
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DemoAPI.Data.Models.Database.Student", "Student")
                        .WithMany("StudentCourse")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
