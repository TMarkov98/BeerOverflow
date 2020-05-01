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
    public class BeersDrankController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BeersDrankController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: BeersDrank
        public async Task<IActionResult> Index()
        {
            var beerOverflowContext = _context.BeersDrank.Where(wb => wb.User.UserName == HttpContext.User.Identity.Name).Include(b => b.Beer).Include(b => b.User);
            return View(await beerOverflowContext.ToListAsync());
        }

        // GET: BeersDrank/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            var userCollection = _context.Users.Where(u => u.UserName == HttpContext.User.Identity.Name);
            if (id != null && id != 0)
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

        // POST: BeersDrank/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,BeerId")] BeerDrank beerDrank)
        {
            if (ModelState.IsValid)
            {
                var beersDrankExists = _context.BeersDrank.FirstOrDefault(wb => wb.UserId == beerDrank.UserId && wb.BeerId == beerDrank.BeerId);
                if (beersDrankExists == null)
                {
                    _context.Add(beerDrank);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BeerId"] = new SelectList(_context.Beers, "Id", "Name", beerDrank.BeerId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Email", beerDrank.UserId);
            return View(beerDrank);
        }
        // GET: BeersDrank/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? userId, int? beerId)
        {
            if (userId == null || beerId == null)
            {
                return NotFound();
            }

            var beerDrank = await _context.BeersDrank
                .Include(b => b.Beer)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.UserId == userId && m.BeerId == beerId);
            if (beerDrank == null)
            {
                return NotFound();
            }

            return View(beerDrank);
        }

        // POST: BeersDrank/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int userId, int beerId)
        {
            var beerDrank = await _context.BeersDrank.FindAsync(userId, beerId);
            _context.BeersDrank.Remove(beerDrank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BeerDrankExists(int id)
        {
            return _context.BeersDrank.Any(e => e.UserId == id);
        }
    }
}
