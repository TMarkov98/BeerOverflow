using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerOverflow.Database;
using BeerOverflow.Models;

namespace BeerOverflow.Web.Controllers
{
    public class BeersController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BeersController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Beers
        public async Task<IActionResult> Index()
        {
            var beerOverflowContext = _context.Beers.Include(b => b.Brewery).Include(b => b.Type);
            return View(await beerOverflowContext.ToListAsync());
        }

        // GET: Beers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers
                .Include(b => b.Brewery)
                .Include(b => b.Type)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beer == null)
            {
                return NotFound();
            }

            return View(beer);
        }

        // GET: Beers/Create
        public IActionResult Create()
        {
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.Set<BeerType>(), "Id", "Name");
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,TypeId,BreweryId,CreatedOn,DeletedOn,ModifiedOn,IsDeleted,AlcoholByVolume")] Beer beer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name", beer.BreweryId);
            ViewData["TypeId"] = new SelectList(_context.Set<BeerType>(), "Id", "Name", beer.TypeId);
            return View(beer);
        }

        // GET: Beers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beer = await _context.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name", beer.BreweryId);
            ViewData["TypeId"] = new SelectList(_context.Set<BeerType>(), "Id", "Name", beer.TypeId);
            return View(beer);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TypeId,BreweryId,CreatedOn,DeletedOn,ModifiedOn,IsDeleted,AlcoholByVolume")] Beer beer)
        {
            if (id != beer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerExists(beer.Id))
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
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name", beer.BreweryId);
            ViewData["TypeId"] = new SelectList(_context.Set<BeerType>(), "Id", "Name", beer.TypeId);
            return View(beer);
        }

        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }
    }
}
