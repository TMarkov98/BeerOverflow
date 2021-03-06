﻿using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        // POST: Breweries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
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
        private bool BreweryExists(int id)
        {
            return _context.Breweries.Any(e => e.Id == id);
        }
    }
}
