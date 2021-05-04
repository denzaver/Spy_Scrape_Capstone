using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spy_Scrape.Data;
using Spy_Scrape.Models;

namespace Spy_Scrape.Controllers
{
    public class TrafficeSourcesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrafficeSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TrafficeSources
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrafficeSources.ToListAsync());
        }

        // GET: TrafficeSources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trafficeSource = await _context.TrafficeSources
                .FirstOrDefaultAsync(m => m.TrafficSourceId == id);
            if (trafficeSource == null)
            {
                return NotFound();
            }

            return View(trafficeSource);
        }

        // GET: TrafficeSources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrafficeSources/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrafficSourceId,TrafficSourceName")] TrafficeSource trafficeSource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trafficeSource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trafficeSource);
        }

        // GET: TrafficeSources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trafficeSource = await _context.TrafficeSources.FindAsync(id);
            if (trafficeSource == null)
            {
                return NotFound();
            }
            return View(trafficeSource);
        }

        // POST: TrafficeSources/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrafficSourceId,TrafficSourceName")] TrafficeSource trafficeSource)
        {
            if (id != trafficeSource.TrafficSourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trafficeSource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrafficeSourceExists(trafficeSource.TrafficSourceId))
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
            return View(trafficeSource);
        }

        // GET: TrafficeSources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trafficeSource = await _context.TrafficeSources
                .FirstOrDefaultAsync(m => m.TrafficSourceId == id);
            if (trafficeSource == null)
            {
                return NotFound();
            }

            return View(trafficeSource);
        }

        // POST: TrafficeSources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trafficeSource = await _context.TrafficeSources.FindAsync(id);
            _context.TrafficeSources.Remove(trafficeSource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrafficeSourceExists(int id)
        {
            return _context.TrafficeSources.Any(e => e.TrafficSourceId == id);
        }
    }
}
