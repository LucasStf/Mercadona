using Mercadona.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mercadona.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<ProduitsModel> Produits { get; set; }
        DbSet<CategorieModel> Categorie { get; set; }
        DbSet<PromotionsModel> Promotions { get; set;}
        DbSet<PromotionsProduitsModel> PromotionsProduits { get; set; }
    }
}