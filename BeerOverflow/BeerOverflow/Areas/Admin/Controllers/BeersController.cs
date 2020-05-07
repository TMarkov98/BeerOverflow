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
    public class BeersController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BeersController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Admin/Beers
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {

            var beers = _context.Beers
                .Where(b => !b.IsDeleted)
                .Include(b => b.Brewery)
                .Include(b => b.Type).AsQueryable();

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
                beers = beers.Where(b => b.Name.ToLower().Contains(searchString.ToLower())
                                       || b.Brewery.Name.ToLower().Contains(searchString.ToLower())
                                       || b.Type.Name.ToLower().Contains(searchString.ToLower())).AsQueryable();
            }
            int pageSize = 12;
            return View(await PaginatedList<Beer>.CreateAsync(beers, pageNumber ?? 1, pageSize));
        }

        // GET: Admin/Beers/Details/5
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

        // GET: Admin/Beers/Create
        public IActionResult Create()
        {
            ViewData["BreweryId"] = new SelectList(_context.Breweries, "Id", "Name");
            ViewData["TypeId"] = new SelectList(_context.BeerTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/Beers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["TypeId"] = new SelectList(_context.BeerTypes, "Id", "Name", beer.TypeId);
            return View(beer);
        }

        // GET: Admin/Beers/Edit/5
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
            ViewData["TypeId"] = new SelectList(_context.BeerTypes, "Id", "Name", beer.TypeId);
            return View(beer);
        }

        // POST: Admin/Beers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,TypeId,BreweryId,DeletedOn,ModifiedOn,IsDeleted,AlcoholByVolume,ImgUrl")] Beer beer)
        {
            if (id != beer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (beer.IsDeleted)
                        beer.DeletedOn = DateTime.Now;
                    beer.ModifiedOn = DateTime.Now;
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
            ViewData["TypeId"] = new SelectList(_context.BeerTypes, "Id", "Name", beer.TypeId);
            return View(beer);
        }

        // GET: Admin/Beers/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Admin/Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beer = await _context.Beers.FindAsync(id);
            _context.Beers.Remove(beer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddToWishlist(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            var beer = _context.Beers.FirstOrDefault(b => b.Id == Id);
            var wishlistExists = _context.WishlistBeers.FirstOrDefault(l => l.UserId == user.Id && l.BeerId == Id);
            if (wishlistExists == null)
            {
                var wishlist = new WishlistBeer
                {
                    UserId = user.Id,
                    User = user,
                    BeerId = (int)Id,
                    Beer = beer
                };
                _context.WishlistBeers.Add(wishlist);
                _context.SaveChanges();
            }
            return Redirect("~/WishlistBeers");
        }
        public IActionResult AddToBeersDrank(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            var beer = _context.Beers.FirstOrDefault(b => b.Id == Id);
            var beerDrankExists = _context.BeersDrank.FirstOrDefault(l => l.UserId == user.Id && l.BeerId == Id);
            if (beerDrankExists == null)
            {
                var beerDrank = new BeerDrank
                {
                    UserId = user.Id,
                    User = user,
                    BeerId = (int)Id,
                    Beer = beer
                };
                _context.BeersDrank.Add(beerDrank);
                _context.SaveChanges();
            }
            return Redirect("~/BeersDrank");
        }
        public IActionResult Like(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var user = _context.Users.FirstOrDefault(u => u.UserName == HttpContext.User.Identity.Name);
            var beer = _context.Beers.FirstOrDefault(b => b.Id == Id);
            var likeExists = _context.Likes.FirstOrDefault(l => l.UserId == user.Id && l.BeerId == Id);
            if (likeExists == null)
            {
                var like = new Like
                {
                    UserId = user.Id,
                    User = user,
                    BeerId = (int)Id,
                    Beer = beer
                };
                _context.Likes.Add(like);
            }
            else
            {
                _context.Likes.Remove(likeExists);
            }
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = Id });
        }
        private bool BeerExists(int id)
        {
            return _context.Beers.Any(e => e.Id == id);
        }
    }
}
