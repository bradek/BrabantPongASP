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
    public class SpelersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpelersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Spelers
        public async Task<IActionResult> Index()
        {
            /*Ik heb de query op dusdanige wijze gewijzigd dat daar waar IsDeleted op 'true' staat, wordt verborgen.
             Ik maak namelijk gebruik van een soft delete.
            Alleen de 'niet-verwijderden' worden hierbij weergegeven.*/
            var spelers = from s in _context.Spelers
                          where !s.IsDeleted
                                && (s.Club == null || !s.Club.IsDeleted)
                                && (s.Ranking == null || !s.Ranking.IsDeleted)
                          select s;

            return View(await spelers.ToListAsync());
        }

        // GET: Spelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers
                .Include(s => s.Club)
                .Include(s => s.Ranking)
                .FirstOrDefaultAsync(m => m.SpelerId == id);
            if (speler == null)
            {
                return NotFound();
            }

            return View(speler);
        }

        // GET: Spelers/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "ClubNaam");
            ViewData["RankingId"] = new SelectList(_context.Rankings, "RankingId", "RankingNaam");
            return View();
        }

        // POST: Spelers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpelerId,SpelerVoornaam,SpelerAchternaam,ClubId,RankingId")] Speler speler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "ClubNaam", speler.ClubId);
            ViewData["RankingId"] = new SelectList(_context.Rankings, "RankingId", "RankingNaam", speler.RankingId);
            return View(speler);
        }

        // GET: Spelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers.FindAsync(id);
            if (speler == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "ClubNaam", speler.ClubId);
            ViewData["RankingId"] = new SelectList(_context.Rankings, "RankingId", "RankingNaam", speler.RankingId);
            return View(speler);
        }

        // POST: Spelers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpelerId,SpelerVoornaam,SpelerAchternaam,ClubId,RankingId")] Speler speler)
        {
            if (id != speler.SpelerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(speler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpelerExists(speler.SpelerId))
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
            ViewData["ClubId"] = new SelectList(_context.Clubs, "ClubId", "ClubNaam", speler.ClubId);
            ViewData["RankingId"] = new SelectList(_context.Rankings, "RankingId", "RankingNaam", speler.RankingId);
            return View(speler);
        }

        // GET: Spelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Spelers
                .Include(s => s.Club)
                .Include(s => s.Ranking)
                .FirstOrDefaultAsync(m => m.SpelerId == id);
            if (speler == null)
            {
                return NotFound();
            }

            return View(speler);
        }

        // POST: Spelers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speler = await _context.Spelers.FindAsync(id);
            if (speler != null)
            {
                /*Ik heb de methode licht gewijzigd.
                 In plaats van echt te verwijderen, wijzig ik de IsDeleted property.
                De IsDeleted properties waarbij 'true' staat, zullen niet worden weergegeven.
                Deze worden slechts verborgen.*/
                speler.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SpelerExists(int id)
        {
            return _context.Spelers.Any(e => e.SpelerId == id);
        }
    }
}