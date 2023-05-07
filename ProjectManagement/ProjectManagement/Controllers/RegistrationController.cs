using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Signup()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
