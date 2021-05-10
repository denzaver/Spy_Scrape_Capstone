using Microsoft.EntityFrameworkCore;
using Spy_Scrape.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public class AdRepository : IAdRepository
    {
        private  ApplicationDbContext _context;
        public AdRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Ad> GetAllAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory);
            }
        }
        
        public void CreateAd(Ad ad)
        {
            _context.Add(ad);
            _context.SaveChanges();
        }
        public IEnumerable<Ad> GetAllFacebookAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory).Where(c => c.AdTrafficSource == "Facebook");
            }
        }

        public IEnumerable<Ad> GetAllInstagramAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory).Where(c => c.AdTrafficSource == "Instagram");
            }
        }
        public IEnumerable<Ad> GetAllTikTokAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory).Where(c => c.AdTrafficSource == "TikTok");
            }
        }

        public Ad GetAdById(int Id)
        {
            return _context.Ads.FirstOrDefault(a => a.AdId == Id);
        }

        public void EditAd(Ad ad)
        {
            _context.Entry(ad).State=EntityState.Modified;
            _context.SaveChanges();

        }

        public void DeleteAd(int Id)
        {
            var adToDelete = _context.Ads.Find(Id);
            _context.Ads.Remove(adToDelete);
            _context.SaveChanges();

            //var adToDelete = _context.Ads.FirstOrDefault(d => d.AdId == Id);
            //if( adToDelete != null)
            //{
            //    _context.Remove(adToDelete);
            //    _context.SaveChanges();

            //}
        }
    }
}
