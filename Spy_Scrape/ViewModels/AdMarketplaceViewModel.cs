using Spy_Scrape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.ViewModels
{
    public class AdMarketplaceViewModel
    {
        public IEnumerable<Ad> Ads { get; set; }
        public string CurrentCategory { get; set; }
    }
}
