using BeerOverflow.Database;
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
    public class ReviewsController : Controller
    {
        private readonly BeerOverflowContext _context;

        public ReviewsController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var beerOverflowContext = _context.Reviews
                .Where(r => !r.IsDeleted)
                .OrderByDescending(r => r.Id)
                .Include(r => r.Author)
                .Include(r => r.TargetBeer);
            return View(await beerOverflowContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .Include(r => r.Author)
                .Include(r => r.TargetBeer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public IActionResult Create(int? id)
        {
            var userName = HttpContext.User.Identity.Name;
            var user = _context.Users.Where(u => u.UserName == userName);
            if (user == null)
                return BadRequest();
            var beer = _context.Beers.Where(b => b.Id == id);
            if (user == null)
                return BadRequest();
            ViewData["AuthorId"] = new SelectList(user, "Id", "Email");
            ViewData["TargetBeerId"] = new SelectList(beer, "Id", "Name");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rating,Name,Text,TargetBeerId,AuthorId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", review.AuthorId);
            ViewData["TargetBeerId"] = new SelectList(_context.Beers, "Id", "Name", review.TargetBeerId);
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userName = HttpContext.User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                return BadRequest();
            var userId = user.Id;
            var review = await _context.Reviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            if (review.AuthorId != userId)
            {
                return BadRequest("You can edit only Your reviews");
            }
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", review.AuthorId);
            ViewData["TargetBeerId"] = new SelectList(_context.Beers, "Id", "Name", review.TargetBeerId);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,Name,Text,TargetBeerId,AuthorId,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    review.ModifiedOn = DateTime.Now;
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
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
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Email", review.AuthorId);
            ViewData["TargetBeerId"] = new SelectList(_context.Beers, "Id", "Name", review.TargetBeerId);
            return View(review);
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
