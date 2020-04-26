using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BeerOverflow.Web.Controllers
{
    public class BeerTypesController : Controller
    {
        private readonly BeerOverflowContext _context;

        public BeerTypesController(BeerOverflowContext context)
        {
            _context = context;
        }

        // GET: BeerTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BeerTypes.ToListAsync());
        }

        // GET: BeerTypes/Details/5
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

        // GET: BeerTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: BeerTypes/Edit/5
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

        // POST: BeerTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedOn,ModifiedOn,IsDeleted,DeletedOn")] BeerType beerType)
        {
            if (id != beerType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
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
        private bool BeerTypeExists(int id)
        {
            return _context.BeerTypes.Any(e => e.Id == id);
        }
    }
}
