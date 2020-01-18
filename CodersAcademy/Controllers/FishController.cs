using CodersAcademy.Filter;
using CodersAcademy.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Underwater.Controllers
{
    [Authorize]
    public class FishController : Controller
    {
        private readonly Irepository _repository;
        
        public FishController(Irepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
        
        public IActionResult Index()
        {
            return View(this._repository.GetFishes());
        }

    }
}