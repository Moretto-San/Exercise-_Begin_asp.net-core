using CodersAcademy.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Underwater.ViewModels;

namespace Underwater.Controllers
{
    public class UserAccountController : Controller
    {
        private SignInManager<UserAccount> _signInManager;
        private UserManager<UserAccount> _userManager;

        public UserAccountController(SignInManager<UserAccount> signInManager, UserManager<UserAccount> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Aquarium");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Aquarium");
                }
            }
            ModelState.AddModelError("", "Faild to Login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Aquarium");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                UserAccount student = new UserAccount
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    UserName = registerModel.UserName,
                    PhoneNumber = registerModel.PhoneNumber,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(student, registerModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "UserAccount");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

    }
}