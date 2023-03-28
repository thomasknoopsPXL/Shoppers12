using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shoppers12.Data;
using Shoppers12.Models.Data;

namespace Shoppers12.Controllers
{
    public class ProductCategoriesController : Controller
    {
        private readonly Shoppers12DbContext _context;
        public ProductCategoriesController(Shoppers12DbContext context)
        {
            _context = context;
        }

        // GET: ProductCategoriesController
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductCategories.ToListAsync());
        }

        // GET: ProductCategoriesController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var category = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: ProductCategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductCategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductCategoryId,ProductCategoryName")] ProductCategory productCat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productCat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productCat);
        }

        // GET: ProductCategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ProductCategoriesController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductCategories == null)
            {
                return NotFound();
            }

            var category = await _context.ProductCategories
                .FirstOrDefaultAsync(m => m.ProductCategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: ProductCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            if (_context.ProductCategories == null)
            {
                return Problem("Entity set 'Products'  is null.");
            }
            var category = await _context.ProductCategories.FindAsync(id);
            if (category != null)
            {
                _context.ProductCategories.Remove(category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
