using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Underwater.Models;
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