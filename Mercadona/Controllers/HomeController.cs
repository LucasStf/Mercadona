using Mercadona.Data;
using Mercadona.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Mercadona.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _context = applicationDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CGU()
        {
            return View();
        }

        public async Task<IActionResult> Catalogue(int? categorie)
        {
            var produits = _context.Produits.Include(p => p.CategoriesList).AsQueryable();
            var promotionsProduits = await _context.PromotionsProduits.ToListAsync();
            var promotions = await _context.Promotions.ToListAsync();
            var categories = await _context.Categorie.ToListAsync();

            if (categorie != null)
            {
                var categorie_by_id = categories.FirstOrDefault(c => c.Id == categorie);
                produits = produits.Where(p => p.id_categorie == categorie_by_id.Id);
            }

            var viewModel = new ProduitsViewModel
            {
                Produits = produits.ToList(),
                promotionsProduitsModels = promotionsProduits,
                promotions = promotions,
                CategoriesList = categories
            };

            return View(viewModel);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}