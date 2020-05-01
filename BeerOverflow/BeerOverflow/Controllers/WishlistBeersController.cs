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

namespace BeerOverflow.Web.Controllers
{
    public class WishlistBeersController : Controller
    {
        private readonly BeerOverflowContext _context;

        public WishlistBeersController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: WishlistBeers
        public async Task<IActionResult> Index()
        {
            var beerOverflowContext = _context.WishlistBeers.Where(wb => wb.User.UserName == HttpContext.User.Identity.Name).Include(w => w.Beer).Include(w => w.User);
            return View(await beerOverflowContext.ToListAsync());
        }
        // GET: WishlistBeers/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            var userCollection = _context.Users.Where(u => u.UserName == HttpContext.User.Identity.Name);
            if(id != null && id != 0)
            {
                var beerCollection = _context.Beers.Where(b => b.Id == id);
                ViewData["BeerId"] = new SelectList(beerCollection, "Id", "Name");
            }
            else
            {
                ViewData["BeerId"] = new SelectList(_context.Beers, "Id", "Name");
            }
            ViewData["UserId"] = new SelectList(userCollection, "Id", "Email");
            return View();
        }

        // POST: WishlistBeers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BeerId")] WishlistBeer wishlistBeer)
        {
            if (ModelState.IsValid)
            {
                var wishlistBeerExists = _context.WishlistBeers.FirstOrDefault(wb => wb.UserId == wishlistBeer.UserId && wb.BeerId == wishlistBeer.BeerId);
                if(wishlistBeerExists == null)
                {
                    _context.Add(wishlistBeer);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerId"] = new SelectList(_context.Beers, "Id", "Name", wishlistBeer.BeerId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", wishlistBeer.UserId);
            return View(wishlistBeer);
        }

        // GET: WishlistBeers/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? userId, int? beerId)
        {
            if (userId == null || beerId == null)
            {
                return NotFound();
            }

            var wishlistBeer = await _context.WishlistBeers
                .Include(w => w.Beer)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.UserId == userId && m.BeerId == beerId);
            if (wishlistBeer == null)
            {
                return NotFound();
            }

            return View(wishlistBeer);
        }

        // POST: WishlistBeers/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userId, int beerId)
        {
            var wishlistBeer = await _context.WishlistBeers.FindAsync(userId, beerId);
            _context.WishlistBeers.Remove(wishlistBeer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistBeerExists(int id)
        {
            return _context.WishlistBeers.Any(e => e.UserId == id);
        }
    }
}
