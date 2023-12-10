using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrabantPongASP.Data;
using BrabantPongASP.Models;

namespace BrabantPongASP.Controllers
{
    public class ScheidsrechtersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScheidsrechtersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Scheidsrechters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Scheidsrechters.ToListAsync());
        }

        // GET: Scheidsrechters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheidsrechter = await _context.Scheidsrechters
                .FirstOrDefaultAsync(m => m.ScheidsrechterId == id);
            if (scheidsrechter == null)
            {
                return NotFound();
            }

            return View(scheidsrechter);
        }

        // GET: Scheidsrechters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Scheidsrechters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheidsrechterId,ScheidsrechterNaam")] Scheidsrechter scheidsrechter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheidsrechter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheidsrechter);
        }

        // GET: Scheidsrechters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheidsrechter = await _context.Scheidsrechters.FindAsync(id);
            if (scheidsrechter == null)
            {
                return NotFound();
            }
            return View(scheidsrechter);
        }

        // POST: Scheidsrechters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheidsrechterId,ScheidsrechterNaam")] Scheidsrechter scheidsrechter)
        {
            if (id != scheidsrechter.ScheidsrechterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheidsrechter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScheidsrechterExists(scheidsrechter.ScheidsrechterId))
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
            return View(scheidsrechter);
        }

        // GET: Scheidsrechters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheidsrechter = await _context.Scheidsrechters
                .FirstOrDefaultAsync(m => m.ScheidsrechterId == id);
            if (scheidsrechter == null)
            {
                return NotFound();
            }

            return View(scheidsrechter);
        }

        // POST: Scheidsrechters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scheidsrechter = await _context.Scheidsrechters.FindAsync(id);
            if (scheidsrechter != null)
            {
                _context.Scheidsrechters.Remove(scheidsrechter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScheidsrechterExists(int id)
        {
            return _context.Scheidsrechters.Any(e => e.ScheidsrechterId == id);
        }
    }
}
