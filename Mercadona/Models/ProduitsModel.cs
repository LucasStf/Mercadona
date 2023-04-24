namespace Mercadona.Models
{

    public class ProduitsViewModel
    {
        public List<ProduitsModel> Produits { get; set; }

        public List<PromotionsProduitsModel> promotionsProduitsModels { get; set; }

        public List<PromotionsModel> promotions { get; set; }
    }

    public class ProduitsModel
    {
        public int Id { get; set; }
        public string libelle { get; set; }
        public string description { get; set; }
        public float prix { get; set; }

        public int id_categorie { get; set; }
        public IEnumerable<CategorieModel> CategoriesList { get; set; }
        public IEnumerable<PromotionsProduitsModel> promotionsProduitsModels { get; set; }
        public IEnumerable<PromotionsModel> promotionsModels { get; set; }

        public string url_image { get; set; }
    }
}