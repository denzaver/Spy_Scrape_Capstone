using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spy_Scrape.Models;

namespace Spy_Scrape.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IAdCategoryRepository _adCategoryRepository;

        public CategoryMenu(IAdCategoryRepository adCategoryRepository)
        {
            _adCategoryRepository = adCategoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _adCategoryRepository.GetAdCategories().OrderBy(c => c.CategoryType);
            return View(categories);
        }
    }
}
