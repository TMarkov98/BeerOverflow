using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    public class BreweriesController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BreweriesController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Breweries
        public async Task<IActionResult> Index(string searchString)
        {
            var beerOverflowContext = _context.Breweries.Include(b => b.Country);
            

            var breweries = await beerOverflowContext.ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                breweries = breweries.Where(b => b.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)
                                       || b.Country.Name.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            return View(breweries);
        }

        // GET: Breweries/Details/5
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

        // GET: Breweries/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Breweries/Edit/5
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

        // POST: Breweries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CountryId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Brewery brewery)
        {
            if (id != brewery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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

        private bool BreweryExists(int id)
        {
            return _context.Breweries.Any(e => e.Id == id);
        }
    }
}
