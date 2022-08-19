using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceRepositoryPattern.Data;
using ServiceRepositoryPattern.Models;
using ServiceRepositoryPattern.Services;

namespace ServiceRepositoryPattern.Controllers
{
    public class FoodItemsController : Controller
    {
        private readonly ServiceRepositoryPatternContext _context;

        public FoodItemsController(ServiceRepositoryPatternContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return _context.FoodItem != null ?
                        View(await _context.FoodItem.ToListAsync()) :
                        Problem("Entity set 'ServiceRepositoryPatternContext.FoodItem'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FoodItem == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,SalePrice,UnitPrice,Quantity")] FoodItem foodItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FoodItem == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound();
            }
            return View(foodItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,SalePrice,UnitPrice,Quantity")] FoodItem foodItem)
        {
            if (id != foodItem.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(foodItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodItemExists(foodItem.ID))
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
            return View(foodItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FoodItem == null)
            {
                return NotFound();
            }

            var foodItem = await _context.FoodItem
                .FirstOrDefaultAsync(m => m.ID == id);
            if (foodItem == null)
            {
                return NotFound();
            }

            return View(foodItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FoodItem == null)
            {
                return Problem("Entity set 'ServiceRepositoryPatternContext.FoodItem'  is null.");
            }
            var foodItem = await _context.FoodItem.FindAsync(id);
            if (foodItem != null)
            {
                _context.FoodItem.Remove(foodItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodItemExists(int id)
        {
            return (_context.FoodItem?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
