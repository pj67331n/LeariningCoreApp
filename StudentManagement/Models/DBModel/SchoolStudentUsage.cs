using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models.DBModel
{
    public class SchoolStudentUsage
    {
        [Key]
        public int StudentId { get; set; }

        [Key]
       
        public int SchoolId { get; set; }

        public bool Active { get; set; }
    }
}
