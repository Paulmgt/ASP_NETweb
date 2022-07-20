using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppTp2.Models;

namespace WebAppTp2.Controllers
{
    public class VoituresController : Controller
    {
        private readonly VoitureDbEntities _context;
        // Crée un field qui fournit les information sur l'environnement
        // Par exmpl la racine du site

        IWebHostEnvironment _webHostenvironment;

        public VoituresController(VoitureDbEntities context, IWebHostEnvironment webHostenvironment)
        {
            _context = context;
            _webHostenvironment = webHostenvironment;
        }

        // GET: Voitures
        public async Task<IActionResult> Index()
        {
            var voitureDbEntities = _context.Voitures.Include(v => v.Marque);
            return View(await voitureDbEntities.ToListAsync());
        }

        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .Include(v => v.Marque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Create
        public IActionResult Create()
        {
            ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom");
            return View();
        }

        // POST: Voitures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Voiture voiture, IFormFile Photo)
        {
            // Verifier si la photo est bonne : Taille non null
            if(Photo.Length > 0)
            if (ModelState.IsValid)
            {
                    // Recuperer le chemin du dossier qui contient les phoros
                    string rootPath = _webHostenvironment.WebRootPath;
                    string fileName = Path.GetFileName(Photo.FileName) + "_" + Guid.NewGuid() + Path .GetExtension(Photo.FileName);
                    string path = Path.Combine(rootPath + "/photoVoitures/", fileName);
                    // Copier physiquement le fichier dans les dossier photoImages
                    // On utilse le fileStream

                    var fileStream = new FileStream(path, FileMode.Create);
                    // Copie en async

                    await Photo.CopyToAsync(fileStream);

                    fileStream.Close();
                    voiture.Photo = fileName;


                _context.Add(voiture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom", voiture.MarqueId);
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }
            ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom", voiture.MarqueId);
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Photo,MarqueId,Model,Chassis,Finition,NbPortes,Moteur,ChevauxDin,Couleur")] Voiture voiture)
        {
            if (id != voiture.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voiture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoitureExists(voiture.Id))
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
            ViewData["MarqueId"] = new SelectList(_context.Marques, "Id", "Nom", voiture.MarqueId);
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voitures == null)
            {
                return NotFound();
            }

            var voiture = await _context.Voitures
                .Include(v => v.Marque)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voitures == null)
            {
                return Problem("Entity set 'VoitureDbEntities.Voitures'  is null.");
            }
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoitureExists(int id)
        {
          return (_context.Voitures?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
