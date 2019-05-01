using Microsoft.EntityFrameworkCore;
using StudentManagement.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<SchoolStudentUsage> SchoolStudentUsages { get; set; }

        public DbSet<CourseStudentUsage> StudentCourseUsages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SchoolStudentUsage>().HasKey(c => new { c.StudentId, c.SchoolId });
            modelBuilder.Entity<CourseStudentUsage>().HasKey(c => new { c.CourseId, c.StudentId });
        }
    }
}
