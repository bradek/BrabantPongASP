using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrabantPongASP.Data;
using BrabantPongASP.Models;

namespace BrabantPongASP.Controllers
{
    public class ToernooisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToernooisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Toernoois
        public async Task<IActionResult> Index()
        {
            return View(await _context.Toernooien.ToListAsync());
        }

        // GET: Toernoois/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooi = await _context.Toernooien
                .FirstOrDefaultAsync(m => m.ToernooiId == id);
            if (toernooi == null)
            {
                return NotFound();
            }

            return View(toernooi);
        }

        // GET: Toernoois/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Toernoois/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToernooiId,ToernooiNaam")] Toernooi toernooi)
        {

                if (ModelState.IsValid)
                {
                    _context.Add(toernooi);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            return View(toernooi);
        }

        // GET: Toernoois/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooi = await _context.Toernooien.FindAsync(id);
            if (toernooi == null)
            {
                return NotFound();
            }
            return View(toernooi);
        }

        // POST: Toernoois/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToernooiId,ToernooiNaam")] Toernooi toernooi)
        {
            if (id != toernooi.ToernooiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toernooi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToernooiExists(toernooi.ToernooiId))
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
            return View(toernooi);
        }

        // GET: Toernoois/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toernooi = await _context.Toernooien
                .FirstOrDefaultAsync(m => m.ToernooiId == id);
            if (toernooi == null)
            {
                return NotFound();
            }

            return View(toernooi);
        }

        // POST: Toernoois/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toernooi = await _context.Toernooien.FindAsync(id);
            if (toernooi != null)
            {
                _context.Toernooien.Remove(toernooi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToernooiExists(int id)
        {
            return _context.Toernooien.Any(e => e.ToernooiId == id);
        }
    }
}
