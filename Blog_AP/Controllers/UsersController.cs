using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Blog_AP;
using Blog_AP.Models;
using Blog_AP.Data;

namespace Blog_AP.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
              return _context.User != null ? 
                          View(await _context.User.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.User'  is null.");
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            //ViewBag.Roles = new SelectList(_context.Role, "RoleName", "RoleName");
            //ViewBag.Faculties = new SelectList(_context.Faculty, "FacultyName", "FacultyName");

            ViewBag.Roles = _context.Role
                .Select(r => r.RoleName)
                .ToList();

            ViewBag.Faculties = _context.Faculty
                .Select(f => f.FacultyName)
                .ToList();

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,UserEmail,UserPassword,Role,Faculty")] User user)
        {
            if (ModelState.IsValid)
            {
                var selectedRole = _context.Role.FirstOrDefault(c => c.RoleName == user.Role.RoleName);

                user.Role = selectedRole;

                var selectedFaculty = _context.Faculty.FirstOrDefault(c => c.FacultyName == user.Faculty.FacultyName);

                user.Faculty = selectedFaculty;

                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .Include(u => u.Role)
                .Include(u => u.Faculty)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            /*ViewBag.Roles = _context.Role
                .Select(r => r.RoleName)
                .ToList();

            ViewBag.Faculties = _context.Faculty
                .Select(f => f.FacultyName)
                .ToList();*/
            ViewBag.Roles = new SelectList(_context.Role, "RoleName", "RoleName", user.Role.RoleName);
            ViewBag.Faculties = new SelectList(_context.Faculty, "FacultyName", "FacultyName", user.Faculty.FacultyName);

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,UserEmail,UserPassword,Role,Faculty")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the selected role by name
                    var selectedRole = _context.Role.FirstOrDefault(c => c.RoleName == user.Role.RoleName);

                    // Update the user's role based on the selected role name
                    user.Role = selectedRole;

                    // Retrieve the selected role by name
                    var selectedFaculty = _context.Faculty.FirstOrDefault(c => c.FacultyName == user.Faculty.FacultyName);

                    // Update the user's role based on the selected role name
                    user.Faculty = selectedFaculty;

                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.User == null)
            {
                return NotFound();
            }

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ApplicationDbContext.User'  is null.");
            }
            var user = await _context.User.FindAsync(id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
          return (_context.User?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
