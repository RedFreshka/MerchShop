using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MerchShop.Data.Interfaces;
using MerchShop.Data.Models;
using MerchShop.Models;
using MerchShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MerchShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;
        private readonly ICategory _category;
        private readonly ISubcategory _subcategory;
        private readonly ISize _size;

        public ProductController(IProduct product, ICategory category, ISubcategory subcategory, ISize size)
        {
            _product = product;
            _category = category;
            _subcategory = subcategory;
            _size = size;
        }
        [Route("Product/ListProducts")]
        [Route("Product/ListProducts/{subcategory}")]
        public ViewResult ListProducts( string subcategory)
        {
            var info = HttpContext.Session.GetString("SessionUserData");
            if(info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
            }

            IEnumerable<Product> products = null;
            string productSubcategory = "";
            if (string.IsNullOrEmpty(subcategory))
            {
                products = _product.GetProducts.OrderBy(t => t.Id);
            }
            else
            {
                products = _product.GetProducts
                    .Where(x => x.Subcategory.SubcategoryName.ToLower() == subcategory.ToLower());
                productSubcategory = subcategory;
            }
            var carObj = new ProductListViewModel
            {
                GetProducts = products,
                ProductSubcategory = productSubcategory
            };

            return View(carObj);
        }
    }
}