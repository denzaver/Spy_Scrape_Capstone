using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spy_Scrape.Data;
using Spy_Scrape.Models;
using Spy_Scrape.ViewModels;
using Stripe;

namespace Spy_Scrape.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {

            _context = context;
            StripeConfiguration.ApiKey = "sk_test_ny2MVIMOlATJZvdyyoVZie6Q";
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return RedirectToAction("AdMarketplace", "Ads" );
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return RedirectToAction("AdMarketplace", "Ads");
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var options = new ChargeCreateOptions
            {
                Amount = 2000,
                Currency = "usd",
                Source = stripeToken,
                Description = "My First Test Charge (created for API docs)",
            };
            var service = new ChargeService();
            var charged = service.Create(options);


            if (charged.Status == "succeeded")
            {
                string BalanceTransactionId = charged.BalanceTransactionId;
                return View();
            }

            return RedirectToAction("AdMarketplace", "Ads");
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }


        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Models.Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        public IActionResult FavoriteAds()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var vm = new FavoriteAdsViewModel();
            vm.Ads = _context.Favorites.Where(a => a.Customer.CustomerId == customer.CustomerId).Select(a => a.Ad);

            return View(vm);
        }

        public IActionResult FavoriteAdsAdd(int id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(x => x.IdentityUserId == userId).FirstOrDefault();
            var favAd = _context.Favorites.SingleOrDefault(f => f.Ad.AdId == id && f.Customer.CustomerId == customer.CustomerId);
            
            if (favAd == null)
            {
                var ad = _context.Ads.SingleOrDefault(a => a.AdId == id);
                favAd = new Favorite
                {
                    Ad = ad,
                    Customer = customer,
                };

                _context.Add(favAd);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public bool AdExists(int AdId)
        {
            return _context.Favorites.Any(a => a.Ad.AdId == AdId);
        }
    }
}
