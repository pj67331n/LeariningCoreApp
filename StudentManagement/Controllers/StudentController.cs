using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.Models.DBModel;
using StudentManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext db;

        public StudentController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            List<StudentViewModel> result = new List<StudentViewModel>();
            var students = db.Students;
            foreach (var student in students)
            {
                var item = new StudentViewModel();
                item.Student = student;
                item.Schools = GetSchools(student.StudentId);
                result.Add(item);
            }
            return View(result);
        }


        // Ajax call for student data 
       

        [HttpPost]
        public IActionResult Edit(StudentViewModel studentViewModel)
        {
            Student oldStudent = db.Students.Where(x => x.StudentId == studentViewModel.Student.StudentId).FirstOrDefault();
            //oldStudent = studentViewModel.Student;
            //oldStudent = new Student {
            //    StudentId = studentViewModel.Student.StudentId,
            //    FirstName = studentViewModel.Student.FirstName,
            //    LastName = studentViewModel.Student.LastName,
            //    DateOfBirth = studentViewModel.Student.DateOfBirth
            //};
            oldStudent.StudentId = studentViewModel.Student.StudentId;
            oldStudent.FirstName = studentViewModel.Student.FirstName;
            oldStudent.LastName = studentViewModel.Student.LastName;
            oldStudent.DateOfBirth = studentViewModel.Student.DateOfBirth;

           var removeUsage =  db.SchoolStudentUsages.Where(x => x.StudentId == studentViewModel.Student.StudentId);
            db.SchoolStudentUsages.RemoveRange(removeUsage);
            var usage = new SchoolStudentUsage
            {
                StudentId = studentViewModel.Student.StudentId,
                SchoolId = studentViewModel.Schools.Count > 0 ? studentViewModel.Schools[0].School.SchoolId : 0,
                Active = true
            };
            db.SchoolStudentUsages.Add(usage);
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }

        [HttpGet]
        public IActionResult Edit(int studentId)
        { 
            StudentViewModel student = new StudentViewModel
            {
                Student = db.Students.Where(x => x.StudentId == studentId).FirstOrDefault(),
                Schools = GetSchools(studentId),     
            };
            ViewBag.Schools = db.Schools;
            return View(student);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Schools = db.Schools;
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel studentViewModel)
        {
            db.Students.Add(studentViewModel.Student);
            db.SaveChanges();
            var usage = new SchoolStudentUsage
            {
                StudentId = studentViewModel.Student.StudentId,
                SchoolId = studentViewModel.Schools.Count > 0 ? studentViewModel.Schools[0].School.SchoolId : 0,
                Active = true
            };
            db.SchoolStudentUsages.Add(usage);
            db.SaveChanges();
            return RedirectToAction("Index", "Student");
        }

        public IActionResult Delete(List<int> studentIds)
        {
            var removeUsage = db.SchoolStudentUsages.Where(x => studentIds.Contains(x.StudentId));
            db.SchoolStudentUsages.RemoveRange(removeUsage);
            var removeStudent = db.Students.Where(x => studentIds.Contains(x.StudentId));
            db.RemoveRange(removeStudent);
            db.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        //public IActionResult Delete(int[] studentIds)
        //{
        //    var removeUsage = db.SchoolStudentUsages.Where(x => studentIds.Contains(x.StudentId));
        //    db.SchoolStudentUsages.RemoveRange(removeUsage);
        //    var removeStudent = db.Students.Where(x => studentIds.Contains(x.StudentId));
        //    db.RemoveRange(removeStudent);
        //    db.SaveChanges();
        //    return Json(1);
        //}

        // private fn
        private List<SchoolCourseViewModel> GetSchools(int studentId)
        {
            var schoolIds = db.SchoolStudentUsages.Where(s => s.StudentId == studentId).Select(s => s.SchoolId);
            //return new List<SchoolCourseViewModel> {
            //     db.Schools.Where(s => schoolIds.Contains(s.SchoolId)).ToList();
            //}
            return db.Schools.Where(s => schoolIds.Contains(s.SchoolId)).Select(s => new SchoolCourseViewModel
            {
                School = s,
                Courses = new List<Course>(),
            }).ToList();
        }

    }
}
