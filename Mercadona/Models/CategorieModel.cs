using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadona.Models
{
    public class CategorieViewModel
    {
        public List<CategorieModel> Categories { get; set; }
    }

    public class CategorieModel
    {
        public int Id { get; set; }
        public string libelle { get; set; }
    }
}
