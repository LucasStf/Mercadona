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
    public class PromotionsProduitsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionsProduitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void InitializeProduits(PromotionsProduitsModel model)
        {
            model.Produits = _context.Produits.ToList();
        }

        private void InitializePromotions(PromotionsProduitsModel model)
        {
            model.Promotions = _context.Promotions.ToList();
        }


        // GET: PromotionsProduits
        public async Task<IActionResult> Index()
        {
              return _context.PromotionsProduits != null ? 
                          View(await _context.PromotionsProduits.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PromotionsProduits'  is null.");
        }

        // GET: PromotionsProduits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PromotionsProduits == null)
            {
                return NotFound();
            }

            var promotionsProduitsModel = await _context.PromotionsProduits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotionsProduitsModel == null)
            {
                return NotFound();
            }

            return View(promotionsProduitsModel);
        }

        // GET: PromotionsProduits/Create
        public IActionResult Create()
        {
            PromotionsProduitsModel model = new PromotionsProduitsModel();
            InitializeProduits(model);
            InitializePromotions(model);
            return View(model);
        }

        // POST: PromotionsProduits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProduit,IdPromotion,prixPromo")] PromotionsProduitsModel promotionsProduitsModel)
        {
            var produit = _context.Produits.Find(promotionsProduitsModel.IdProduit);
            var promotion = _context.Promotions.Find(promotionsProduitsModel.IdPromotion);

            // Calculer le prix en promotion
            var prixEnPromo = produit.prix - (produit.prix * promotion.PourcentageRemise / 100);

            promotionsProduitsModel.prixPromo = prixEnPromo;

            _context.Add(promotionsProduitsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PromotionsProduits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PromotionsProduits == null)
            {
                return NotFound();
            }

            var promotionsProduitsModel = await _context.PromotionsProduits.FindAsync(id);
            if (promotionsProduitsModel == null)
            {
                return NotFound();
            }
            InitializeProduits(promotionsProduitsModel);
            InitializePromotions(promotionsProduitsModel);
            return View(promotionsProduitsModel);
        }

        // POST: PromotionsProduits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProduit,IdPromotion,prixPromo")] PromotionsProduitsModel promotionsProduitsModel)
        {
            if (id != promotionsProduitsModel.Id)
            {
                return NotFound();
            }


                try
                {
                    var produit = _context.Produits.Find(promotionsProduitsModel.IdProduit);
                    var promotion = _context.Promotions.Find(promotionsProduitsModel.IdPromotion);

                    // Calculer le prix en promotion
                    var prixEnPromo = produit.prix - (produit.prix * promotion.PourcentageRemise / 100);

                    promotionsProduitsModel.prixPromo = prixEnPromo;

                    _context.Update(promotionsProduitsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionsProduitsModelExists(promotionsProduitsModel.Id))
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

        // GET: PromotionsProduits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PromotionsProduits == null)
            {
                return NotFound();
            }

            var promotionsProduitsModel = await _context.PromotionsProduits
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotionsProduitsModel == null)
            {
                return NotFound();
            }

            return View(promotionsProduitsModel);
        }

        // POST: PromotionsProduits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PromotionsProduits == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PromotionsProduits'  is null.");
            }
            var promotionsProduitsModel = await _context.PromotionsProduits.FindAsync(id);
            if (promotionsProduitsModel != null)
            {
                _context.PromotionsProduits.Remove(promotionsProduitsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionsProduitsModelExists(int id)
        {
          return (_context.PromotionsProduits?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
