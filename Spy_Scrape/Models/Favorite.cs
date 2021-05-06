using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public List<Ad> Ads { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
