using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using ProjectManagement.Logic.Interfaces;

namespace ProjectManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = studentService.GetStudents();
            return View(students);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentService.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Student updatedStudent)
        {
            if (id != updatedStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    studentService.UpdateStudent(updatedStudent);
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
                return RedirectToAction("Index");
            }
            return View(updatedStudent);
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            try
            {
                studentService.RemoveStudent(id);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(string id)
        {
            var student = studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
