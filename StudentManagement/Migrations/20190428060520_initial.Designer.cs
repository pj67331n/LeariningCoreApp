﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Models;

namespace StudentManagement.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20190428060520_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentManagement.Models.DBModel.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.Property<int>("SchoolId");

                    b.HasKey("CourseId");

                    b.HasIndex("SchoolId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudentManagement.Models.DBModel.CourseStudentUsage", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.Property<bool>("Active");

                    b.Property<double>("Grade");

                    b.HasKey("CourseId", "StudentId");

                    b.ToTable("StudentCourseUsages");
                });

            modelBuilder.Entity("StudentManagement.Models.DBModel.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolName");

                    b.HasKey("SchoolId");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("StudentManagement.Models.DBModel.SchoolStudentUsage", b =>
                {
                    b.Property<int>("StudentId");

                    b.Property<int>("SchoolId");

                    b.Property<bool>("Active");

                    b.HasKey("StudentId", "SchoolId");

                    b.HasAlternateKey("SchoolId", "StudentId");

                    b.ToTable("SchoolStudentUsages");
                });

            modelBuilder.Entity("StudentManagement.Models.DBModel.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentManagement.Models.DBModel.Course", b =>
                {
                    b.HasOne("StudentManagement.Models.DBModel.School", "School")
                        .WithMany("Courses")
                        .HasForeignKey("SchoolId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
