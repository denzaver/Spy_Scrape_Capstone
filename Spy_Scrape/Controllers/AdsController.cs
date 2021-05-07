﻿using System;
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
        readonly ApplicationDbContext _context;
        private readonly IAdRepository _adRepository;
        private readonly IAdCategoryRepository _adCategoryRepository;

        public AdsController(ApplicationDbContext context, IAdRepository adRepository, IAdCategoryRepository adCategoryRepository)
        {
            //_context = context;
            _adRepository = adRepository;
            _adCategoryRepository = adCategoryRepository;
        }

        // GET: Ads
        public IActionResult Index()
        {
            
            //var adsView = _context.Ads.ToList();
            
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

                currentCategory = _adCategoryRepository.GetAdCategories.FirstOrDefault(c => c.CategoryType == category)?.CategoryType;
            }

            return View(new AdMarketplaceViewModel
            {
                Ads = ads,
                CurrentCategory = currentCategory
            });
            //var adsCatalog = _context.Ads.ToList();
            //ViewBag.FacebookCategory = "Facebook Ads";
            //return View(_adRepository.GetAllAds);
        }

        // GET: Ads/Details/5
        public IActionResult Details(int id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

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
           
            return View();
        }

        // POST: Ads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AdId,AdOs,AdTargetMarket,AdMarketCountry,ImageURL,CategoryId,TrafficSourceId")] Ad ad)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Categories = _context.Ads.Select(x => x.AdCategory).Distinct();
                var addAd = new Ad();
                addAd.AdOs = ad.AdOs;
                addAd.AdTargetMarket = ad.AdTargetMarket;
                addAd.AdMarketCountry = ad.AdMarketCountry;
                addAd.ImageURL = ad.ImageURL;
                addAd.AdCategory = ad.AdCategory;
                addAd.TrafficeSource = ad.TrafficeSource;
                _adRepository.CreateAd(addAd);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.AdCategories, "CategoryId", "CategoryType");
            return RedirectToAction(nameof(Index));
        }

        // GET: Ads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads.FindAsync(id);
            if (ad == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.AdCategories, "CategoryId", "CategoryId", ad.CategoryId);
            return View(ad);
        }

        // POST: Ads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AdId,AdOs,AdTargetMarket,AdMarketCountry,ImageURL,CategoryId,TrafficSourceId")] Ad ad)
        {
            if (id != ad.AdId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ad);
                    await _context.SaveChangesAsync();
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
            ViewData["CategoryId"] = new SelectList(_context.AdCategories, "CategoryId", "CategoryId", ad.CategoryId);
            return View(ad);
        }

        // GET: Ads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ad = await _context.Ads
                .Include(a => a.AdCategory)
                .FirstOrDefaultAsync(m => m.AdId == id);
            if (ad == null)
            {
                return NotFound();
            }

            return View(ad);
        }

        // POST: Ads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ad = await _context.Ads.FindAsync(id);
            _context.Ads.Remove(ad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdExists(int id)
        {
            return _context.Ads.Any(e => e.AdId == id);
        }
    }
}
