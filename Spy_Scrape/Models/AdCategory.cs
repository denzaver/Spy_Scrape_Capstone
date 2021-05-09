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
        public string CategoryType { get; set; }
        public List<Ad> Ads { get; set; }
    }
}
