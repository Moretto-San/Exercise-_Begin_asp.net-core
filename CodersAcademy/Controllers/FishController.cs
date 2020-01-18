using CodersAcademy.Filter;
using CodersAcademy.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Underwater.Controllers
{
    //[LogActionFilter]
    public class FishController : Controller
    {
        private readonly IRepository _repository;
        
        public FishController(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
        
        public IActionResult Index()
        {
            return View();
        }

    }
}