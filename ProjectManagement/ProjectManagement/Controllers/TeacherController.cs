﻿
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;

namespace ProjectManagement.Controllers
{
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
            var teachers = teacherService.GetTeachers();
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
                teacherService.UpdateTeacher(teacher);
                return RedirectToAction(nameof(Index));
            }

            return View(teacher);
        }

        [HttpDelete]
        public IActionResult DeleteConfirmed(Guid id)
        {
            teacherService.RemoveTeacher(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            var student = teacherService.GetTeacherById(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
    }
}
