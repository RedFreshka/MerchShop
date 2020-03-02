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

namespace MerchShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFDbContext _context;
        public HomeController(EFDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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
            //FileService service = new FileService();
            //await service.AddFile(uploadedFile);
            return RedirectToAction("Login", "Account");
        }
    }
}
