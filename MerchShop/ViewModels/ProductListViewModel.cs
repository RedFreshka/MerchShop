using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> GetProducts { get; set; }
        public string ProductSubcategory { get; set; }
    }
}
