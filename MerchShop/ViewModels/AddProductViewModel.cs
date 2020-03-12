using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.ViewModels
{
    public class AddProductViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int SubcategoryId { get; set; }

        [Display(Name ="Add Image")]
        public string ImageName { get; set; }

    }
}
