using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;
using ProjectManagement.Logic;
using ProjectManagement.Models;
using System.Security.Claims;

namespace ProjectManagement.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserService userService;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, UserService userService)
        {
            userManager = userManager;
            signInManager = signInManager;
            userService = userService;
        }
    //[HttpGet]
    //[AllowAnonymous]
    //public IActionResult Register()
    //{
    //    return View();
    //}
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }

        public async Task<IActionResult> View()
        {
            var identityUser = await userManager.GetUserAsync(User);
            if (identityUser == null)
            {
                return NotFound();
            }
            var user = userService.Get(identityUser.Id);    
            var model = new AccountInfoViewModel
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Description = user.Description,
                ProfilePicturePath = user.ProfilePicturePath
            };

            return View(model);
        }

        //public IActionResult View()
        //{
        //    var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Retrieve the user from the database based on the ID
        //    var user = userService.Get(loggedInUserId);

        //    if (user == null)
        //    {
        //        // Handle the case when the user is not found
        //        return NotFound();
        //    }

        //    // Pass the user to the view
        //    return View(user);
        //}

      
    }
}
    

