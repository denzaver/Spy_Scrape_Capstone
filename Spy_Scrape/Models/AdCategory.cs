using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class AdCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "Ad Type")]
        public string CategoryType { get; set; }
        //public string CategoryName { get; set; }

        //public string CategoryDiscription { get; set; }

        public List<Ad> Ads { get; set; }
    }
}
