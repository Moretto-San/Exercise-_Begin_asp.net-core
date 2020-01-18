using CodersAcademy.Filter;
using CodersAcademy.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Underwater.Controllers
{
    //[LogActionFilter]
    public class AquariumController : Controller
    {
        private readonly IRepository _repository;
        
        public AquariumController(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
        
        public IActionResult Index()
        {
            return View();
        }

    }
}