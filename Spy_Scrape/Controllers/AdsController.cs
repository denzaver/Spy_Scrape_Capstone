using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spy_Scrape.Data;
using Spy_Scrape.Models;
using Spy_Scrape.ViewModels;

namespace Spy_Scrape.Controllers
{
    public class AdsController : Controller
    {
        
        private  IAdRepository _adRepository;
        private  IAdCategoryRepository _adCategoryRepository;

        public AdsController(IAdRepository adRepository, IAdCategoryRepository adCategoryRepository)
        {
            _adRepository = adRepository;
            _adCategoryRepository = adCategoryRepository;
        }

        // GET: Ads
        public IActionResult Index()
        {
            return View(_adRepository.GetAllAds);
        }
        [Authorize]
        public IActionResult AdMarketplace(string category)
        {
            IEnumerable<Ad> ads;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                ads = _adRepository.GetAllAds.OrderBy(a => a.AdId);
                currentCategory = "All Ads";
            }
            else
            {
                ads = _adRepository.GetAllAds.Where(c => c.AdCategory.CategoryType == category);

                currentCategory = _adCategoryRepository.GetAdCategories().FirstOrDefault(c => c.CategoryType == category)?.CategoryType;
            }

            return View(new AdMarketplaceViewModel
            {
                Ads = ads,
                CurrentCategory = currentCategory
            }
            );
        }
        // GET: Ads/Details/5
        public IActionResult AdDetails(int id)
        {
            var ad = _adRepository.GetAdById(id);

            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }
        // GET: Ads/Create
        public IActionResult Create()
        {
            var categoryList = _adCategoryRepository.GetAdCategories().ToList();
            ViewBag.AdCategory = new SelectList(categoryList, "CategoryId", "CategoryType");
            return View();
        }
        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create([Bind("AdId,AdType,AdTrafficSource,AdOS,AdTargetMarket,AdTargetCountry,ImageURL,AdVies,AdRunTime,CategoryId,AdCategory")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                var addAd = new Ad();
                addAd.AdId = ad.AdId;
                addAd.AdType = ad.AdType;
                addAd.AdTrafficSource = ad.AdTrafficSource;
                addAd.AdOS = ad.AdOS;
                addAd.AdTargetMarket = ad.AdTargetMarket;
                addAd.AdTargetCountry = ad.AdTargetCountry;
                addAd.ImageURL = ad.ImageURL;
                addAd.AdVies = ad.AdVies;
                addAd.AdRunTime = ad.AdRunTime;
                addAd.CategoryId = ad.CategoryId;
                addAd.AdCategory = ad.AdCategory;

                _adRepository.CreateAd(addAd);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Ads/Edit/5
        public IActionResult Edit(int id)
        {
            var categoryList = _adCategoryRepository.GetAdCategories().ToList();
            ViewBag.AdCategory = new SelectList(categoryList, "CategoryId", "CategoryType");

            if (id == null)
            {
                return NotFound();
            }
            var ad = _adRepository.GetAllAds.FirstOrDefault(a => a.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit([Bind("AdId,AdType,AdTrafficSource,AdOS,AdTargetMarket,AdTargetCountry,ImageURL,AdVies,AdRunTime,CategoryId,AdCategory")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _adRepository.EditAd(ad);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdExists(ad.AdId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ad);
        }

        // GET: Ads/Delete/5
        public IActionResult Delete(int id)
        {
            var categoryList = _adCategoryRepository.GetAdCategories().ToList();
            ViewBag.AdCategory = new SelectList(categoryList, "CategoryId", "CategoryType");

            if (id == null)
            {
                return NotFound();
            }

            var ad = _adRepository.GetAllAds.FirstOrDefault(a => a.AdId == id);
                //.Include(a => a.AdCategory)
                //.FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _adRepository.DeleteAd(id);
            return RedirectToAction(nameof(Index));
        }

        public bool AdExists(int AdId)
        {
            return _adRepository.GetAllAds.Any(a => a.AdId == AdId);
        }
    }
}
