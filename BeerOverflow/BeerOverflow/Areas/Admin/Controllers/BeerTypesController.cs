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
    public class BeerTypesController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BeerTypesController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Admin/BeerTypes
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {
            var beerTypes = _context.BeerTypes
                .Where(b => !b.IsDeleted).AsQueryable();
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
                beerTypes = beerTypes.Where(b => b.Name.ToLower().Contains(searchString.ToLower()));
            }
            int pageSize = 12;
            return View(await PaginatedList<BeerType>.CreateAsync(beerTypes, pageNumber ?? 1, pageSize));
        }

        // GET: Admin/BeerTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerType = await _context.BeerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beerType == null)
            {
                return NotFound();
            }

            return View(beerType);
        }

        // GET: Admin/BeerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BeerTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] BeerType beerType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beerType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beerType);
        }

        // GET: Admin/BeerTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerType = await _context.BeerTypes.FindAsync(id);
            if (beerType == null)
            {
                return NotFound();
            }
            return View(beerType);
        }

        // POST: Admin/BeerTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ModifiedOn,IsDeleted,DeletedOn")] BeerType beerType)
        {
            if (id != beerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (beerType.IsDeleted)
                        beerType.DeletedOn = DateTime.Now;
                    beerType.ModifiedOn = DateTime.Now;
                    _context.Update(beerType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BeerTypeExists(beerType.Id))
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
            return View(beerType);
        }

        // GET: Admin/BeerTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beerType = await _context.BeerTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beerType == null)
            {
                return NotFound();
            }

            return View(beerType);
        }

        // POST: Admin/BeerTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beerType = await _context.BeerTypes.FindAsync(id);
            _context.BeerTypes.Remove(beerType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerTypeExists(int id)
        {
            return _context.BeerTypes.Any(e => e.Id == id);
        }
    }
}
