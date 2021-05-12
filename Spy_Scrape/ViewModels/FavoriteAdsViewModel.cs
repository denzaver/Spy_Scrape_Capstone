using Spy_Scrape.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.ViewModels
{
    public class FavoriteAdsViewModel
    {
        public IEnumerable<Ad> Ads { get; set; }
    }
}
