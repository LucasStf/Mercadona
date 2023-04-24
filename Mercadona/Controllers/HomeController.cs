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

        public async Task<IActionResult> Catalogue()
        {
            var produits = await _context.Produits.ToListAsync();
            var promotionsProduits = await _context.PromotionsProduits.ToListAsync();
            var promotions = await _context.Promotions.ToListAsync();

            var viewModel = new ProduitsViewModel
            {
                Produits = produits,
                promotionsProduitsModels = promotionsProduits,
                promotions = promotions
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