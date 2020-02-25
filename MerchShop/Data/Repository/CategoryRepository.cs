using MerchShop.Data.EFContext;
using MerchShop.Data.Interfaces;
using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly EFDbContext _context;
        public CategoryRepository(EFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetCategories => _context.Categories;
    }
}
