﻿using System;
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
        public int Id { get; set; }
        public string AdSource { get; set; } // TrafficSource
        public string AdType { get; set; } // Category
        public string AdOs { get; set; }
        public string AdTargetMarket { get; set; }
        public string AdMarketCountry { get; set; }

        [ForeignKey("TrafficSource")]
        public int TrafficSourceId { get; set; }
        public TrafficeSource TrafficeSource { get; set; }

    }
}
