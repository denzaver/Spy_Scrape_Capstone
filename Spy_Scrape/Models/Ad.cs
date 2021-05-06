using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class Ad
    {
        [Key]
        public int AdId { get; set; }
        public string AdOs { get; set; }
        public string AdTargetMarket { get; set; }
        public string AdMarketCountry { get; set; }
        public string ImageURL { get; set; }
     
        [ForeignKey("AdCategory")]
        public int CategoryId { get; set; }
        public AdCategory AdCategory { get; set; }
        

        [ForeignKey("TrafficSource")]
        public int TrafficSourceId { get; set; }
        public TrafficeSource TrafficeSource { get; set; }

    }
}
