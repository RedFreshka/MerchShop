using MerchShop.Data.EFContext;
using MerchShop.Data.Interfaces;
using MerchShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Repository
{
    public class SizeRepository : ISize
    {
        private readonly EFDbContext _context;
        public SizeRepository(EFDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Size> GetSizes => _context.Sizes;
    }
}
