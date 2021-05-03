using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class Ad
    {
        [Key]
        public int Id { get; set; }
        public string AdSource { get; set; }
        public string AdType { get; set; }
        public string AdOs { get; set; }
        public string AdTargetMarket { get; set; }
    }
}
