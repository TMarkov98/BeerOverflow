using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Authorization;

namespace BeerOverflow.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BreweriesController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BreweriesController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Admin/Breweries
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {
            var breweries = _context.Breweries
                .Where(b => !b.IsDeleted)
                .Include(b => b.Country).AsQueryable();

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                breweries = breweries.Where(b => b.Name.ToLower().Contains(searchString.ToLower())
                                       || b.Country.Name.ToLower().Contains(searchString.ToLower()));
            }
            int pageSize = 12;
            return View(await PaginatedList<Brewery>.CreateAsync(breweries, pageNumber ?? 1, pageSize));
        }

        // GET: Admin/Breweries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Breweries
                .Include(b => b.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery);
        }

        // GET: Admin/Breweries/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Admin/Breweries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CountryId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Brewery brewery)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brewery);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", brewery.CountryId);
            return View(brewery);
        }

        // GET: Admin/Breweries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Breweries.FindAsync(id);
            if (brewery == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", brewery.CountryId);
            return View(brewery);
        }

        // POST: Admin/Breweries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId,IsDeleted,DeletedOn,ModifiedOn")] Brewery brewery)
        {
            if (id != brewery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (brewery.IsDeleted)
                        brewery.DeletedOn = DateTime.Now;
                    brewery.ModifiedOn = DateTime.Now;
                    _context.Update(brewery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreweryExists(brewery.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name", brewery.CountryId);
            return View(brewery);
        }

        // GET: Admin/Breweries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brewery = await _context.Breweries
                .Include(b => b.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brewery == null)
            {
                return NotFound();
            }

            return View(brewery);
        }

        // POST: Admin/Breweries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);
            _context.Breweries.Remove(brewery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreweryExists(int id)
        {
            return _context.Breweries.Any(e => e.Id == id);
        }
    }
}
