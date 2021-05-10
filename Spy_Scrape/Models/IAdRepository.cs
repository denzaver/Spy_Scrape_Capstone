using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spy_Scrape.Models
{
    public interface IAdRepository
    {
        IEnumerable<Ad> GetAllAds { get; }
        void CreateAd(Ad ad);
        IEnumerable<Ad> GetAllFacebookAds { get; }
        IEnumerable<Ad> GetAllInstagramAds { get; }
        IEnumerable<Ad> GetAllTikTokAds { get; }
        Ad GetAdById(int AdId);
        void  EditAd(Ad ad);
        

    }
}
