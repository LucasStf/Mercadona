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
    public class PromotionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Promotions
        public async Task<IActionResult> Index()
        {
              return _context.Promotions != null ? 
                          View(await _context.Promotions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Promotions'  is null.");
        }

        // GET: Promotions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotionsModel = await _context.Promotions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotionsModel == null)
            {
                return NotFound();
            }

            return View(promotionsModel);
        }

        // GET: Promotions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promotions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateDebut,DateFin,PourcentageRemise")] PromotionsModel promotionsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promotionsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promotionsModel);
        }

        // GET: Promotions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotionsModel = await _context.Promotions.FindAsync(id);
            if (promotionsModel == null)
            {
                return NotFound();
            }
            return View(promotionsModel);
        }

        // POST: Promotions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateDebut,DateFin,PourcentageRemise")] PromotionsModel promotionsModel)
        {
            if (id != promotionsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promotionsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromotionsModelExists(promotionsModel.Id))
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
            return View(promotionsModel);
        }

        // GET: Promotions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Promotions == null)
            {
                return NotFound();
            }

            var promotionsModel = await _context.Promotions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (promotionsModel == null)
            {
                return NotFound();
            }

            return View(promotionsModel);
        }

        // POST: Promotions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Promotions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Promotions'  is null.");
            }
            var promotionsModel = await _context.Promotions.FindAsync(id);
            if (promotionsModel != null)
            {
                _context.Promotions.Remove(promotionsModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromotionsModelExists(int id)
        {
          return (_context.Promotions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
