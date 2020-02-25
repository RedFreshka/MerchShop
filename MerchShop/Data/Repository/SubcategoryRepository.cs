using MerchShop.Data.EFContext;
using MerchShop.Data.Interfaces;
using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Repository
{
    public class SubcategoryRepository : ISubcategory
    {
        private readonly EFDbContext _context;
        public SubcategoryRepository(EFDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Subcategory> GetSubcategories => _context.Subcategories;
    }
}
