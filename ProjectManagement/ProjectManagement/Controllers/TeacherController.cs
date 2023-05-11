
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using System.Data;

namespace ProjectManagement.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private readonly TeacherService teacherService;

        public TeacherController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        // GET: TeacherController

        [HttpGet]
        public IActionResult Index()
        {
            var teachers = teacherService.GetAll();
            return View(teachers);
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherService.AddTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacherService.Update(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpDelete]
        public IActionResult DeleteConfirmed(string id)
        {
            var teacher = teacherService.FindByCondition(t=>t.Id == id).FirstOrDefault();
            teacherService.RemoveTeacher(teacher);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var student = teacherService.FindByCondition(t => t.Id == id).FirstOrDefault();
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
