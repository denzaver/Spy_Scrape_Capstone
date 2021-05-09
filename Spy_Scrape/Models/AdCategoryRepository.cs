using Spy_Scrape.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class AdCategoryRepository : IAdCategoryRepository
    {
        private  ApplicationDbContext _applicationDbContext;

        public AdCategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<AdCategory> GetAdCategories()
        {
            return _applicationDbContext.AdCategories.ToList();
        }

    }
}
