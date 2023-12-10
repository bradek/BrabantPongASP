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
    public class ToernooiScheidsrechtersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToernooiScheidsrechtersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToernooiScheidsrechters
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ToernooiScheidsrechters.Include(t => t.Scheidsrechter).Include(t => t.Toernooi);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ToernooiScheidsrechters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooiScheidsrechter = await _context.ToernooiScheidsrechters
                .Include(t => t.Scheidsrechter)
                .Include(t => t.Toernooi)
                .FirstOrDefaultAsync(m => m.ToernooiScheidsrechterId == id);
            if (toernooiScheidsrechter == null)
            {
                return NotFound();
            }

            return View(toernooiScheidsrechter);
        }

        // GET: ToernooiScheidsrechters/Create
        public IActionResult Create()
        {
            ViewData["ScheidsrechterId"] = new SelectList(_context.Scheidsrechters, "ScheidsrechterId", "ScheidsrechterNaam");
            ViewData["ToernooiId"] = new SelectList(_context.Toernooien, "ToernooiId", "ToernooiNaam");
            return View();
        }

        // POST: ToernooiScheidsrechters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToernooiScheidsrechterId,ToernooiId,ScheidsrechterId")] ToernooiScheidsrechter toernooiScheidsrechter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toernooiScheidsrechter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ScheidsrechterId"] = new SelectList(_context.Scheidsrechters, "ScheidsrechterId", "ScheidsrechterNaam", toernooiScheidsrechter.ScheidsrechterId);
            ViewData["ToernooiId"] = new SelectList(_context.Toernooien, "ToernooiId", "ToernooiNaam", toernooiScheidsrechter.ToernooiId);
            return View(toernooiScheidsrechter);
        }

        // GET: ToernooiScheidsrechters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooiScheidsrechter = await _context.ToernooiScheidsrechters.FindAsync(id);
            if (toernooiScheidsrechter == null)
            {
                return NotFound();
            }
            ViewData["ScheidsrechterId"] = new SelectList(_context.Scheidsrechters, "ScheidsrechterId", "ScheidsrechterNaam", toernooiScheidsrechter.ScheidsrechterId);
            ViewData["ToernooiId"] = new SelectList(_context.Toernooien, "ToernooiId", "ToernooiNaam", toernooiScheidsrechter.ToernooiId);
            return View(toernooiScheidsrechter);
        }

        // POST: ToernooiScheidsrechters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToernooiScheidsrechterId,ToernooiId,ScheidsrechterId")] ToernooiScheidsrechter toernooiScheidsrechter)
        {
            if (id != toernooiScheidsrechter.ToernooiScheidsrechterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toernooiScheidsrechter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToernooiScheidsrechterExists(toernooiScheidsrechter.ToernooiScheidsrechterId))
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
            ViewData["ScheidsrechterId"] = new SelectList(_context.Scheidsrechters, "ScheidsrechterId", "ScheidsrechterNaam", toernooiScheidsrechter.ScheidsrechterId);
            ViewData["ToernooiId"] = new SelectList(_context.Toernooien, "ToernooiId", "ToernooiNaam", toernooiScheidsrechter.ToernooiId);
            return View(toernooiScheidsrechter);
        }

        // GET: ToernooiScheidsrechters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooiScheidsrechter = await _context.ToernooiScheidsrechters
                .Include(t => t.Scheidsrechter)
                .Include(t => t.Toernooi)
                .FirstOrDefaultAsync(m => m.ToernooiScheidsrechterId == id);
            if (toernooiScheidsrechter == null)
            {
                return NotFound();
            }

            return View(toernooiScheidsrechter);
        }

        // POST: ToernooiScheidsrechters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toernooiScheidsrechter = await _context.ToernooiScheidsrechters.FindAsync(id);
            if (toernooiScheidsrechter != null)
            {
                _context.ToernooiScheidsrechters.Remove(toernooiScheidsrechter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToernooiScheidsrechterExists(int id)
        {
            return _context.ToernooiScheidsrechters.Any(e => e.ToernooiScheidsrechterId == id);
        }
    }
}
