using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.EF;
using ProjectManagement.Logic;

namespace ProjectManagement.Controllers
{
    public class ViewInfoController : Controller
    {
        private readonly TeacherService teacherService;
        public ViewInfoController(TeacherService teacherService)
        {
            this.teacherService = teacherService;
        }
        public IActionResult Index(Guid userId)
        {
            var user = teacherService.GetTeacherById(userId);
            return View(user);

        }
    }
}
