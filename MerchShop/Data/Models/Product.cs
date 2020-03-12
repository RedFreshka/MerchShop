using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
