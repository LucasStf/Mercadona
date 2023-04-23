namespace Mercadona.Models
{

    public class PromotionProduitViewModel
    {
        public List<PromotionsProduitsModel> PromotionProduit { get; set; }

        public IEnumerable<ProduitsModel> Produits { get; set; }
        public IEnumerable<PromotionsModel> Promotions { get; set; }
    }

    public class PromotionsProduitsModel
    {
        public int Id { get; set; }
        public int IdProduit { get; set; }
        public int IdPromotion { get; set; }
        public int prixPromo { get; set; }

        public IEnumerable<ProduitsModel> Produits { get; set; }
        public IEnumerable<PromotionsModel> Promotions { get; set;}
    }
}