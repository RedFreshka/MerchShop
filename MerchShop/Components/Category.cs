using MerchShop.Data.Interfaces;
using MerchShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Components
{
    public class Category : ViewComponent
    {
        private readonly ICategory _category;
        private readonly ISubcategory _subcategory;
        public Category(ICategory category, ISubcategory subcategory)
        {
            _category = category;
            _subcategory = subcategory;
        }
        public IViewComponentResult Invoke()
        {
            var category = _category.GetCategories;
            var subcategory = _subcategory.GetSubcategories;
            return View(new CategorySubcategoryViewModel()
            {
                Categories = category,
                Subcategories = subcategory
            });
        }
    }
}
