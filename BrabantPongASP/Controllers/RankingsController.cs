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
    public class RankingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RankingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rankings
        public async Task<IActionResult> Index(string sortOrder)
        {
            /*Ik maak de ViewData voor het sorteren per naam en ID.*/
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IdSortParm"] = sortOrder == "ID" ? "id_desc" : "ID";

            /*Ik heb mijn query aangepast zodanig dat alleen items die niet zijn verwijderd worden getoond.
             Ik gebruik als het ware een 'soft delete', waarin ik items verberg i.p.v. te verwijderen.*/
            var rankings = from r in _context.Rankings
                           where !r.IsDeleted
                           select r;
            
            /*Afhankelijk van de geselecteerde filter methode, wordt de lijst anders weergegeven.*/
            switch (sortOrder)
            {
                /*Omgekeerde alfabetische volgorde*/
                case "name_desc":
                    rankings = rankings.OrderByDescending(r => r.RankingNaam);
                    break;
                    /*Oplopende volgorde van ID*/
                case "ID":
                    rankings = rankings.OrderBy(r => r.RankingId);
                    break;
                    /*Aflopende volgorde van ID*/
                case "id_desc":
                    rankings = rankings.OrderByDescending(r => r.RankingId);
                    break;
                    /*Alfabetische volgorde van naam*/
                default:
                    rankings = rankings.OrderBy(r => r.RankingNaam);
                    break;
            }

            return View(await rankings.AsNoTracking().ToListAsync());
        }

        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings
                .FirstOrDefaultAsync(m => m.RankingId == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // GET: Rankings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rankings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RankingId,RankingNaam")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ranking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ranking);
        }

        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }
            return View(ranking);
        }

        // POST: Rankings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RankingId,RankingNaam")] Ranking ranking)
        {
            if (id != ranking.RankingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ranking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(ranking.RankingId))
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
            return View(ranking);
        }

        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Rankings
                .FirstOrDefaultAsync(m => m.RankingId == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking != null)
            {
                /*Ik heb de DeleteConfirmed methode licht gewijzigd.
                 Door de boolean IsDeleted te wijzigen, kan ik items waarbij dit het geval is, verbergen.
                Ik doe dit door een soft delete.*/
                ranking.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int id)
        {
            return _context.Rankings.Any(e => e.RankingId == id);
        }
    }
}