using MerchShop.Data.EFContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MerchShop.Data.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public string Id { get; set; }

        [Required, StringLength(75)]
        public string FirstName { get; set; }

        [Required, StringLength(75)]
        public string LastName { get; set; }

        public string Image { get; set; }
        
        /// <summary>
        /// Дата реєстрації
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        public virtual DbUser User { get; set; }
    }
}
