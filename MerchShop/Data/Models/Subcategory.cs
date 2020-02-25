using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
