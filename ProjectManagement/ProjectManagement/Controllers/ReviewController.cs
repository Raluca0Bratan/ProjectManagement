using Microsoft.AspNetCore.Mvc;

namespace ProjectManagement.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
