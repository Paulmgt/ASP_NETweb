using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TpCRUDMVCScolariteSuivi.Models;

namespace TpCRUDMVCScolariteSuivi.Controllers
{
    public class ParcoursController : Controller
    {
        private readonly ScolariteDbEntities _context;

        public ParcoursController(ScolariteDbEntities context)
        {
            _context = context;
        }

        // GET: Parcours
        public async Task<IActionResult> Index()
        {
            var scolariteDbEntities = _context.Parcours.Include(p => p.Module);
            return View(await scolariteDbEntities.ToListAsync());
        }

        // GET: Parcours/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parcours == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours
                .Include(p => p.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcour == null)
            {
                return NotFound();
            }

            return View(parcour);
        }

        // GET: Parcours/Create
        public IActionResult Create()
        {
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Nom");
            return View();
        }

        // POST: Parcours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Logo,Resume,Infos,ModuleId")] Parcour parcour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parcour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Nom", parcour.ModuleId);
            return View(parcour);
        }

        // GET: Parcours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parcours == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours.FindAsync(id);
            if (parcour == null)
            {
                return NotFound();
            }
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Nom", parcour.ModuleId);
            return View(parcour);
        }

        // POST: Parcours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Logo,Resume,Infos,ModuleId")] Parcour parcour)
        {
            if (id != parcour.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parcour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParcourExists(parcour.Id))
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
            ViewData["ModuleId"] = new SelectList(_context.Modules, "Id", "Nom", parcour.ModuleId);
            return View(parcour);
        }

        // GET: Parcours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parcours == null)
            {
                return NotFound();
            }

            var parcour = await _context.Parcours
                .Include(p => p.Module)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parcour == null)
            {
                return NotFound();
            }

            return View(parcour);
        }

        // POST: Parcours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parcours == null)
            {
                return Problem("Entity set 'ScolariteDbEntities.Parcours'  is null.");
            }
            var parcour = await _context.Parcours.FindAsync(id);
            if (parcour != null)
            {
                _context.Parcours.Remove(parcour);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParcourExists(int id)
        {
          return (_context.Parcours?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
