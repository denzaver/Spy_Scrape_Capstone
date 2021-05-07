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
        private readonly ApplicationDbContext _context;
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
            _context.Ads.Add(ad);
            _context.SaveChangesAsync();
        }
        public IEnumerable<Ad> GetAllFacebookAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory);//.Where(f => f.Facebook);
            }
        }

        public IEnumerable<Ad> GetAllInstagramAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory); //.Where(i => i.Instagram);
            }
        }
        public IEnumerable<Ad> GetAllTikTokAds
        {
            get
            {
                return _context.Ads.Include(c => c.AdCategory); //.Where(t => t.TikTok);
            }
        }

        public Ad GetAdById(int AdId)
        {
            return _context.Ads.FirstOrDefault(a => a.AdId == AdId);
        }
    }
}
