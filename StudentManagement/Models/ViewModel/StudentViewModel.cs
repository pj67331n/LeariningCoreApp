using StudentManagement.Models.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models.ViewModel
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            Schools = new List<SchoolCourseViewModel>();
        }

        public Student Student { get; set; }
            
        public List<SchoolCourseViewModel> Schools  { get; set; } 
    
    }
}
