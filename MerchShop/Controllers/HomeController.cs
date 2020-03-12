using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MerchShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using MerchShop.Services;
using MerchShop.Data.EFContext;
using MerchShop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using MerchShop.Data.Models;
using MerchShop.Data.Interfaces;
using Newtonsoft.Json;

namespace MerchShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly IProduct _product;

        public HomeController(EFDbContext context, IHostingEnvironment env, IProduct product)
        {
            _context = context;
            _env = env;
            _product = product;
        }

        public ViewResult Index()
        {
            string fileDestDir = _env.ContentRootPath;
            fileDestDir = Path.Combine(fileDestDir, "Uploaded");
            var info = HttpContext.Session.GetString("SessionUserData");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
            }

            IEnumerable<Product> products = null;
            string productSubcategory = "";
            products = _product.GetProducts.OrderBy(t => t.Id);
            foreach (var item in products)
            {
                item.Image = Path.Combine("/Liosik", item.Image);
            }
            var carObj = new ProductListViewModel
            {
                GetProducts = products,
                ProductSubcategory = productSubcategory
            };

            return View(carObj);

        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(AddProductViewModel product, IFormFile uploadedFile)
        {
            if (ModelState.IsValid)
            {
                if(uploadedFile != null && uploadedFile.Length > 0)
                {
                    var file = uploadedFile;
                    if (file.Length > 0)
                    {
                        var folderServerPath = _env.ContentRootPath;
                        var folderName = "Uploaded";
                        var fileName = Guid.NewGuid().ToString() + ".jpg";
                        var saveFile = Path.Combine(folderServerPath, folderName, fileName);
                        using (var stream = System.IO.File.Create(saveFile))
                        {
                            await uploadedFile.CopyToAsync(stream);
                        }
                        Product newProduct = new Product()
                        {
                            ProductName = product.Name,
                            Price = Convert.ToDouble(product.Price),
                            Count = product.Count,
                            Description = product.Description,
                            Image = fileName,
                            SubcategoryId = product.SubcategoryId
                        };
                        _context.Products.Add(newProduct);
                        _context.SaveChanges();
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public IActionResult AddFilesForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFilesForm(IFormFile uploadedFile)
        {
            FileService service = new FileService(_context, _env);
            await service.AddFile(uploadedFile);
            return RedirectToAction("Login", "Account");
        }
    }
}
