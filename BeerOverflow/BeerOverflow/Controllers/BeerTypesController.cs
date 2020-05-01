using BeerOverflow.Database;
using BeerOverflow.Models;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(string currentFilter, string searchString, int? pageNumber)
        {
            var beerTypes = _context.BeerTypes.AsQueryable();
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
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeerTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
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
        private bool BeerTypeExists(int id)
        {
            return _context.BeerTypes.Any(e => e.Id == id);
        }
    }
}
