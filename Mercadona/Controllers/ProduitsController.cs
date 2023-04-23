using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mercadona.Data;
using Mercadona.Models;

namespace Mercadona.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void InitializeCategoriesList(ProduitsModel produitsModel)
        {
            produitsModel.CategoriesList = _context.Categorie.ToList();
        }

        // GET: Produits
        public async Task<IActionResult> Index()
        {
              return _context.Produits != null ? 
                          View(await _context.Produits.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Produits'  is null.");
        }

        // GET: Produits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produitsModel = await _context.Produits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitsModel == null)
            {
                return NotFound();
            }

            return View(produitsModel);
        }

        // GET: Produits/Create
        public IActionResult Create()
        {
            ProduitsModel produitsModel = new ProduitsModel();
            InitializeCategoriesList(produitsModel);
            return View(produitsModel);
        }

        // POST: Produits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,libelle,description,prix,id_categorie,url_image")] ProduitsModel produitsModel)
        {
            //var categorie = await _context.Categorie.SingleOrDefaultAsync(c => c.libelle == produitsModel.id_categorie.ToString());
            //int idCategorie = (categorie == null) ? 0 : categorie.Id;

            // Ajouter le produit à la base de données
            _context.Add(produitsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Produits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produitsModel = await _context.Produits.FindAsync(id);
            if (produitsModel == null)
            {
                return NotFound();
            }
            InitializeCategoriesList(produitsModel);
            return View(produitsModel);
        }

        // POST: Produits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,libelle,description,prix,id_categorie,url_image")] ProduitsModel produitsModel)
        {
            if (id != produitsModel.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(produitsModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProduitsModelExists(produitsModel.Id))
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

        // GET: Produits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produitsModel = await _context.Produits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produitsModel == null)
            {
                return NotFound();
            }

            return View(produitsModel);
        }

        // POST: Produits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Produits'  is null.");
            }
            var produitsModel = await _context.Produits.FindAsync(id);
            if (produitsModel != null)
            {
                _context.Produits.Remove(produitsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProduitsModelExists(int id)
        {
          return (_context.Produits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
