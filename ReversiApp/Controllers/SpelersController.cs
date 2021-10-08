using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiApp.DAL;
using ReversiApp.Models;

namespace ReversiApp.Controllers
{
    public class SpelersController : Controller
    {
        private readonly SpelContext _context;

        public SpelersController(SpelContext context)
        {
            _context = context;
        }

        // GET: Spelers
        public async Task<IActionResult> Index()
        {
            var spelContext = _context.Speler.Include(s => s.Spel);
            return View(await spelContext.ToListAsync());
        }

        // GET: Spelers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Speler
                .Include(s => s.Spel)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (speler == null)
            {
                return NotFound();
            }

            return View(speler);
        }

        // GET: Spelers/Create
        public IActionResult Create()
        {
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID");
            return View();
        }

        // POST: Spelers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Email,Password,Token,Kleur,SpelID")] Speler speler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(speler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID", speler.SpelID);
            return View(speler);
        }

        // GET: Spelers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Speler.FindAsync(id);
            if (speler == null)
            {
                return NotFound();
            }
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID", speler.SpelID);
            return View(speler);
        }

        // POST: Spelers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Email,Password,Token,Kleur,SpelID")] Speler speler)
        {
            if (id != speler.Id)
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
                    if (!SpelerExists(speler.Id))
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
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID", speler.SpelID);
            return View(speler);
        }

        // GET: Spelers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speler = await _context.Speler
                .Include(s => s.Spel)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var speler = await _context.Speler.FindAsync(id);
            _context.Speler.Remove(speler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpelerExists(int id)
        {
            return _context.Speler.Any(e => e.Id == id);
        }
    }
}
