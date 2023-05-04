using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.DataAccess.Model;

public class AuthController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private RoleManager<IdentityRole> _roleManager
    {
        get;
    }
    public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }
    public IActionResult SignIn()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInVM signIn, string ReturnUrl)
    {
        User user;
        if (signIn.UsernameOrEmail.Contains("@"))
        {
            user = await _userManager.FindByEmailAsync(signIn.UsernameOrEmail);
        }
        else
        {
            user = await _userManager.FindByNameAsync(signIn.UsernameOrEmail);
        }
        if (user == null)
        {
            ModelState.AddModelError("", "Login ve ya parol yalnisdir");
            return View(signIn);
        }
        var result = await
        _signInManager.PasswordSignInAsync(user, signIn.Password, signIn.RememberMe, true);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Login ve ya parol yalnisdir");
            return View(signIn);
        }
        if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
        return RedirectToAction("Index", "Team", new
        {
            area = "admin"
        });
    }
}