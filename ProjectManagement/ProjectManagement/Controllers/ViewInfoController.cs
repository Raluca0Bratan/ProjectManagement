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
        public IActionResult Index(string userId)
        {
            var user = teacherService.FindByCondition(u=>u.Id==userId);
            return View(user);

        }
    }
}
