using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.Models
{
    public class PromotionViewModel
    {
        public List<PromotionsModel> Promotions { get; set; }
    }

    public class PromotionsModel
    {
        public int Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int PourcentageRemise { get; set; }
    }
}
