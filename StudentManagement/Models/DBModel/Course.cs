using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models.DBModel
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }

        public int SchoolId { get; set; }

        public virtual School School { get; set; }

        public string CourseName { get; set; }


    }
}
