using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class TrafficeSource
    {
        [Key]
        public int TrafficSourceId { get; set; }
        public string TrafficSourceName { get; set; }
    }
}
