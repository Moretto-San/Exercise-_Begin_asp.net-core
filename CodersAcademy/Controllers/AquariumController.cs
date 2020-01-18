using CodersAcademy.Filter;
using CodersAcademy.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Models;

namespace Underwater.Controllers
{
    [Authorize]
    public class AquariumController : Controller
    {
        private readonly Irepository Repository;
        
        public AquariumController(Irepository repository)
        {
            Repository = repository ?? throw new ArgumentNullException();
        }
        
        public IActionResult Index()
        {
            return View(this.Repository.GetAquarium());
        }

        // GET: AquariumCode/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = this.Repository.GetAquarium().Where(m => m.AquariumId == id).FirstOrDefault();

            if (aquarium == null)
            {
                return NotFound();
            }

            return View(aquarium);
        }

        // GET: AquariumCode/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AquariumId,Name,Address,Number,Open")] Aquarium aquarium)
        {
            if (ModelState.IsValid)
            {
                ((UnderwaterRepository)this.Repository)._context.Aquariums.Add(aquarium);
                await ((UnderwaterRepository)this.Repository)._context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aquarium);
        }

        // GET: AquariumCode/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = await ((UnderwaterRepository)this.Repository)._context.Aquariums.FindAsync(id);
            if (aquarium == null)
            {
                return NotFound();
            }
            return View(aquarium);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AquariumId,Name,Address,Number,Open")] Aquarium aquarium)
        {
            if (id != aquarium.AquariumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ((UnderwaterRepository)this.Repository)._context.Aquariums.Update(aquarium);
                    await ((UnderwaterRepository)this.Repository)._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AquariumExists(aquarium.AquariumId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aquarium);
        }

        // GET: AquariumCode/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquarium = await ((UnderwaterRepository)this.Repository)._context.Aquariums.FirstOrDefaultAsync(m => m.AquariumId == id);
            if (aquarium == null)
            {
                return NotFound();
            }

            return View(aquarium);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aquarium = await ((UnderwaterRepository)this.Repository)._context.Aquariums.FindAsync(id);
            ((UnderwaterRepository)this.Repository)._context.Aquariums.Remove(aquarium);
            await ((UnderwaterRepository)this.Repository)._context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AquariumExists(int id)
        {
            return ((UnderwaterRepository)this.Repository)._context.Aquariums.Any(e => e.AquariumId == id);
        }

    }
}