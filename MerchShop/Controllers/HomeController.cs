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

namespace MerchShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFDbContext _context;
        private readonly IHostingEnvironment _env;
        public HomeController(EFDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public ViewResult Index()
        {
            return View();
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
                            SizeId = product.SizeId,
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
