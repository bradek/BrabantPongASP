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
    public class ClubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index(string sortOrder)
        {
            /*Ik maak de ViewData's aan voor clubs.
             Ik wil dat er op ID en op naam kan worden geordend.*/
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IdSortParm"] = sortOrder == "ID" ? "id_desc" : "ID";

            /*Met deze gewijzigde query, zorg ik ervoor dat enkel items die niet verwijderd zijn, worden voorgetoond.
             Ik gebruik een 'soft delete' door de 'verwijderde' items te verbergen.*/
            var clubs = from c in _context.Clubs
                        where !c.IsDeleted
                        select c;

            /*Afhankelijk van welke sort order wordt geselecteerd, zal de lijst anders worden weergegeven.*/
            switch (sortOrder)
            {
                //Omgekeerde alfabetische volgorde
                case "name_desc":
                    clubs = clubs.OrderByDescending(c => c.ClubNaam);
                    break;
                //Oplopende volgorde van ID
                case "ID":
                    clubs = clubs.OrderBy(c => c.ClubId);
                    break;
                //Aflopende volgorde van ID
                case "id_desc":
                    clubs = clubs.OrderByDescending(c => c.ClubId);
                    break;
                //Alfabetische volgorde van naam
                case "Name": // Add this case for ascending sorting by name
                    clubs = clubs.OrderBy(c => c.ClubNaam);
                    break;
                default:
                    clubs = clubs.OrderBy(c => c.ClubNaam);
                    break;
            }

            /*Alleen-lezende bewerking, daarom AsNoTracking.
             Zo worden de entiteiten niet bijgehouden voor wijzigingen in de context.*/
            return View(await clubs.AsNoTracking().ToListAsync());
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.ClubId == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clubs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubId,ClubNaam")] Club club)
        {
            if (ModelState.IsValid)
            {
                _context.Add(club);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                return NotFound();
            }
            return View(club);
        }

        // POST: Clubs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubId,ClubNaam")] Club club)
        {
            if (id != club.ClubId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(club);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubExists(club.ClubId))
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
            return View(club);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var club = await _context.Clubs
                .FirstOrDefaultAsync(m => m.ClubId == id);
            if (club == null)
            {
                return NotFound();
            }

            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club != null)
            {
                /*Ik heb deze methode gewijzigd opdat er geen hard delete wordt uitgevoerd.
                 De boolean IsDeleted wordt gewijzigd, zodat dit item kan worden verborgen.*/
                club.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ClubExists(int id)
        {
            return _context.Clubs.Any(e => e.ClubId == id);
        }
    }
}