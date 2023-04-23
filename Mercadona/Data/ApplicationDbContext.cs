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

        public DbSet<ProduitsModel> Produits { get; set; }
        public DbSet<CategorieModel> Categorie { get; set; }
        public DbSet<PromotionsModel> Promotions { get; set;}
        public DbSet<PromotionsProduitsModel> PromotionsProduits { get; set; }
    }
}