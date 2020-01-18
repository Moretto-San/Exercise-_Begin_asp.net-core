using Microsoft.AspNetCore.Mvc;
using Underwater.ViewModels;

namespace Underwater.Controllers
{
    public class UserAccountController : Controller
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

    }
}