using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercadona.Data;
using Mercadona.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Mercadona.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class CategorieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategorieController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorie
        public async Task<IActionResult> Index()
        {
              return _context.Categorie != null ? 
                          View(await _context.Categorie.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Categorie'  is null.");
        }

        // GET: Categorie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieModel == null)
            {
                return NotFound();
            }

            return View(categorieModel);
        }

        // GET: Categorie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,libelle")] CategorieModel categorieModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categorieModel);
        }

        // GET: Categorie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.Categorie.FindAsync(id);
            if (categorieModel == null)
            {
                return NotFound();
            }
            return View(categorieModel);
        }

        // POST: Categorie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,libelle")] CategorieModel categorieModel)
        {
            if (id != categorieModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieModelExists(categorieModel.Id))
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
            return View(categorieModel);
        }

        // GET: Categorie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var categorieModel = await _context.Categorie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorieModel == null)
            {
                return NotFound();
            }

            return View(categorieModel);
        }

        // POST: Categorie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Categorie == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Categorie'  is null.");
            }
            var categorieModel = await _context.Categorie.FindAsync(id);
            if (categorieModel != null)
            {
                _context.Categorie.Remove(categorieModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieModelExists(int id)
        {
          return (_context.Categorie?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
