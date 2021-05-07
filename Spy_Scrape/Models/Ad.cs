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
        public string AdType { get; set; } //vide, photo, slide, carousel
        public string AdTrafficSource { get; set; } //Facebook, Instagram, TikTok
        public string AdOS { get; set; } //What its being show on
        public string AdTargetMarket { get; set; } //Industry
        public string AdTargetCountry { get; set; } //where the add is being ran
        public string ImageURL { get; set; } //the actual ad image
        public string AdVies { get; set; } //how many times the add has been seen
        public string AdRunTime { get; set; } //how long the ad has been runniing
        public bool AdIsActive { get; set; } //is the add currently running

        [ForeignKey("AdCategory")]
        public int CategoryId { get; set; }
        public AdCategory AdCategory { get; set; }


    }
}
