using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppers12.Data;

namespace Shoppers12.Controllers
{
    public class OrderLinesController : Controller
    {
        private readonly Shoppers12DbContext _context;
        public OrderLinesController(Shoppers12DbContext context)
        {
            _context = context;
        }

        // GET: OrderLinesController
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderLines.ToListAsync());
        }

        // GET: OrderLinesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderLinesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderLinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderLinesController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrderLines == null)
            {
                return NotFound();
            }

            var orderLine = await _context.OrderLines
                .FirstOrDefaultAsync(m => m.OrderLineId == id);
            if (orderLine == null)
            {
                return NotFound();
            }

            return View(orderLine);
        }

        // POST: OrderLinesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if(_context.Products == null)
            {
                return Problem("Entity set 'Products'  is null.");
            }
            var artikel = await _context.Products.FindAsync(id);
            if (artikel != null)
            {
                _context.Products.Remove(artikel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
