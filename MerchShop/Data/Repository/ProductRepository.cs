using MerchShop.Data.EFContext;
using MerchShop.Data.Interfaces;
using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly EFDbContext _context;
        public ProductRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProducts => _context.Products;
    }
}
