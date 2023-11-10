using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Models;

namespace MyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyAppContext _context;

        public HomeController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs
        public async Task<IActionResult> Index(string CamionGenre, string searchString)
        {
            if (_context.Chauffeur == null)
            {
                return Problem("Entity set 'MyAppContext.Chauffeur'  is null.");
            }

            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Chauffeur
                                            orderby m.Genre_Camion
                                            select m.Genre_Camion;
            var chauffeurs = from m in _context.Chauffeur
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                chauffeurs = chauffeurs.Where(s => s.Nom!.Contains(searchString) || s.Prenom!.Contains(searchString));
            }

            var CamionGenreVM = new Genre_CamionViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Chauffeurs = await chauffeurs.ToListAsync()
            };

            return View(CamionGenreVM);
        }

        // GET: Chauffeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Chauffeur == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // GET: Chauffeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Prenom,Numero_Camion,Tel_Togo,Tel_Benin,Tel_Niger,Genre_Camion,Proprietaire,Numero_Proprietaire")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chauffeur);
        }

        // GET: Chauffeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Chauffeur == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeur.FindAsync(id);
            if (chauffeur == null)
            {
                return NotFound();
            }
            return View(chauffeur);
        }

        // POST: Chauffeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Prenom,Numero_Camion,Tel_Togo,Tel_Benin,Tel_Niger,Genre_Camion,Proprietaire,Numero_Proprietaire")] Chauffeur chauffeur)
        {
            if (id != chauffeur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurExists(chauffeur.Id))
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
            return View(chauffeur);
        }

        // GET: Chauffeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Chauffeur == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // POST: Chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Chauffeur == null)
            {
                return Problem("Entity set 'MyAppContext.Chauffeur'  is null.");
            }
            var chauffeur = await _context.Chauffeur.FindAsync(id);
            if (chauffeur != null)
            {
                _context.Chauffeur.Remove(chauffeur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private bool ChauffeurExists(int id)
        {
            return (_context.Chauffeur?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}