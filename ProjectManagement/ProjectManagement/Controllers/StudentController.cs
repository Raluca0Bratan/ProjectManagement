using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using ProjectManagement.Logic.Interfaces;
using ProjectManagement.Models;

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

        [HttpGet]
        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(ProjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Map the view model to a Project object
                var project = new Project
                {
                    Name = model.Name,
                    //Description = model.Description,
                    // Set other properties as needed
                };
           
                // Add the project to the current student
                var studentId = "your_current_student_id";
                studentService.AddProjectToStudent(project,studentId);

                // Redirect to a success page or a different action
                return RedirectToAction("ProjectCreated");
            }

            // If the model is not valid, return the view with validation errors
            return View(model);
        }

        public IActionResult ProjectCreated()
        {
            return View();
        }
    }
}
