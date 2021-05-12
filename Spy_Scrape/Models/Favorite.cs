using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public string FavoriteAd { get; set; }

        public Ad Ad { get; set; }
        public Customer Customer { get; set; }



    }
}
