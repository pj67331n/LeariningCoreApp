using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models.DBModel
{
    public class School
    {
        public School()
        {
            this.Courses = new HashSet<Course>();
        }

        [Key]
        public int SchoolId { get; set; }

        public string SchoolName { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
    }
}
