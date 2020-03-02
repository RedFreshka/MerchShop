using MerchShop.Data.EFContext;
using MerchShop.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Services
{
    public class FileService
    {
        private readonly EFDbContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public FileService(EFDbContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public async Task AddFile(IFormFile uploadedFile)
        {
            if(uploadedFile != null)
            {

                string id = Guid.NewGuid().ToString();
                string name = id + ".jpg";
                string path = "/files/" + uploadedFile.FileName;
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Id = id, Name = uploadedFile.FileName, Path = path };
                _context.Files.Add(file);
                _context.SaveChanges();
            }
        }
    }
}
