using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public interface IAdCategoryRepository
    {
        IEnumerable<AdCategory> GetAdCategories();
    }
}
