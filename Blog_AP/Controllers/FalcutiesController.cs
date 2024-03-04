using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog_AP;
using Blog_AP.Models;

namespace Blog_AP.Controllers
{
    public class FalcutiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FalcutiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Falcuties
        public async Task<IActionResult> Index()
        {
              return _context.Falcuty != null ? 
                          View(await _context.Falcuty.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Falcuty'  is null.");
        }

        // GET: Falcuties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Falcuty == null)
            {
                return NotFound();
            }

            var falcuty = await _context.Falcuty
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (falcuty == null)
            {
                return NotFound();
            }

            return View(falcuty);
        }

        // GET: Falcuties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Falcuties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("post_id,user_id")] Falcuty falcuty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(falcuty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(falcuty);
        }

        // GET: Falcuties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Falcuty == null)
            {
                return NotFound();
            }

            var falcuty = await _context.Falcuty.FindAsync(id);
            if (falcuty == null)
            {
                return NotFound();
            }
            return View(falcuty);
        }

        // POST: Falcuties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("post_id,user_id")] Falcuty falcuty)
        {
            if (id != falcuty.post_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(falcuty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FalcutyExists(falcuty.post_id))
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
            return View(falcuty);
        }

        // GET: Falcuties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Falcuty == null)
            {
                return NotFound();
            }

            var falcuty = await _context.Falcuty
                .FirstOrDefaultAsync(m => m.post_id == id);
            if (falcuty == null)
            {
                return NotFound();
            }

            return View(falcuty);
        }

        // POST: Falcuties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Falcuty == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Falcuty'  is null.");
            }
            var falcuty = await _context.Falcuty.FindAsync(id);
            if (falcuty != null)
            {
                _context.Falcuty.Remove(falcuty);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FalcutyExists(int? id)
        {
          return (_context.Falcuty?.Any(e => e.post_id == id)).GetValueOrDefault();
        }
    }
}
