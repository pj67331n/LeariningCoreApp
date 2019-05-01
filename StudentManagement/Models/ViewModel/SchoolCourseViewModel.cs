using StudentManagement.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models.ViewModel
{
    public class SchoolCourseViewModel
    {

        public School School { get; set; }

        public List<Course> Courses { get; set; }
    }
}
