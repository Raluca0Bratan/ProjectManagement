using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic.Interfaces;
using ProjectManagement.Models;
using System.Security.Claims;

namespace ProjectManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(IUserService userService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userService = userService;
            this.userManager = userManager;
            this.signInManager = signInManager; 
        }
        [Authorize(Roles ="Administrator")]
        [HttpGet]
        public IActionResult Index()
        {
            var students = userService.GetAll();
            return View(students);
        }

        [Authorize(Roles ="Student")]
        [HttpGet]
        public async Task<IActionResult> StudentDisciplines()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var disciplines = userService.GetDisciplinesOfStudent(userId);
           return View(disciplines);
        }


        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public async Task<IActionResult> CreateDiscipline(Discipline discipline)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var disciplines = userService.AddDisciplineToTeacher(userId,discipline);
            return View(disciplines);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(User student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userService.Add(student);
        //        return RedirectToAction("Index");
        //    }
        //    return View(student);
        //}

        //[HttpPut]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(string id, User updatedStudent)
        //{
        //    if (id != updatedStudent.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            userService.Update(updatedStudent);
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            return NotFound(ex.Message);
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(updatedStudent);
        //}

        //[HttpDelete]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeleteConfirmed(User user)
        //{
        //    try
        //    {
        //        userService.Remove(user);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //    return RedirectToAction("Index");
        //}
        //[HttpGet]
        //public IActionResult Details(string id)
        //{
        //    var student = userService.GetById(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}

        //[HttpGet]
        //public IActionResult CreateProject()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateProject(ProjectViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Map the view model to a Project object
        //        var project = new Project
        //        {
        //            Name = model.Name,
        //            //Description = model.Description,
        //            // Set other properties as needed
        //        };

        //        // Add the project to the current student
        //        var studentId = "your_current_student_id";
        //        userService.AddProjectToStudent(project, studentId);

        //        // Redirect to a success page or a different action
        //        return RedirectToAction("ProjectCreated");
        //    }

        //    // If the model is not valid, return the view with validation errors
        //    return View(model);
        //}

        //public IActionResult ProjectCreated()
        //{
        //    return View();
        //}

        //public IActionResult StudentDisciplines()
        //{
        //    // Get the current student's disciplines
        //    var student = userManager.GetUserAsync(User); // Implement your own logic to retrieve the current student's ID
        //    var studentDisciplines = userService.GetDisciplinesOfStudent(student.Id.ToString());

        //    // Map the disciplines to a view model
        //    var disciplineViewModels = studentDisciplines.Select(d => new DisciplineViewModel
        //    {
        //        Name = d.Name,
        //        TeacherName = d.Teacher.Name,
        //    }).ToList();

        //    return View(disciplineViewModels);
        //}
        //private string GetCurrentStudentId()
        //{
        //    // Example implementation: return the currently logged-in user's ID
        //    return User.Identity.Name;
        //}


        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var teachers = userService.GetStudents();
        //    return View(teachers);
        //}

        //[HttpPost]
        //public IActionResult Create(User teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userService.(teacher);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(teacher);
        //}

        //[HttpPost]
        //public IActionResult Edit(User teacher)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        userService.Update(teacher);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View(teacher);
        //}

        //[HttpDelete]
        //public IActionResult DeleteConfirmed(string id)
        //{
        //    var teacher = userService.FindByCondition(t => t.Id == id).FirstOrDefault();
        //    userService.Remove(teacher);
        //    return RedirectToAction(nameof(Index));
        //}

        //[HttpGet]
        //public IActionResult Details(string id)
        //{
        //    var student = teacherService.FindByCondition(t => t.Id == id).FirstOrDefault();
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(student);
        //}
    }
}
