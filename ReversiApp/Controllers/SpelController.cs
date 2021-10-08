using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReversiApp.DAL;
using ReversiApp.Models;

namespace ReversiApp.Controllers
{
    public class SpelController : Controller
    {
        private readonly SpelContext _context;
        public SpelController(SpelContext context) {
            _context = context;
        }

        public async Task<ActionResult<SpelComponenten>> Get(string token) {
            int spelerID = (int)HttpContext.Session.GetInt32("ID");
            Speler speler = FindSpelerbyID(spelerID);
            SpelComponenten sc = new SpelComponenten();
            List<Spel> alleSpellen = _context.Spel.ToList();
            foreach (Spel spel in alleSpellen) {
                if (spel.Spelers.Contains(speler)) {
                    sc.Id = spel.ID;
                    sc.Token = spel.Token;
                    sc.Bord = spel.JsonBord;
                    if (spel.AandeBeurt == Kleur.Zwart) {
                        sc.AandeBeurt = 2;
                    }
                    else if (spel.AandeBeurt == Kleur.Wit) {
                        sc.AandeBeurt = 1;
                    }
                    else {
                        sc.AandeBeurt = 0;
                    }
                    return sc;
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Spelbord(int? id) {
            if(id == null) { return NotFound(); }
            var spel = _context.Spel.FirstOrDefault(m => m.ID == id);
            if(spel == null) { return NotFound(); }
            List<Speler> spelers = await _context.Speler.ToListAsync();
            spel.Spelers.Clear();
            foreach (var item in spelers) {
                if(item.SpelID == spel.ID) {
                    spel.Spelers.Add(item);
                }
            }
            return View(spel);
        }

        // GET: Spel
        public IActionResult Index()
        {
            return View(_context.Spel.ToList());
        }

        // GET: Spel/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) {  NotFound(); }
            var spel = _context.Spel
                .Include(b => b.Spelers)
                .FirstOrDefault(m => m.ID == id);
            if (spel == null) { NotFound(); }
            return View(spel);
        }

        // GET: Spel/Create
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Omschrijving, Token, AandeBeurt, JsonBord")] Spel spel)
        {
            if (ModelState.IsValid) {
                _context.Add(spel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        // GET: Spel/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) { return NotFound(); }
            var spel = _context.Spel.Find(id);
            if (spel == null) { return NotFound(); }
            return View(spel);
        }

        // POST: Spel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Omschrijving, Token, AandeBeurt, JsonBord")] Spel spel)
        {
            if (id != spel.ID || !SpelExists(spel.ID)) {
                return NotFound();
            }
            if (ModelState.IsValid) {
                _context.Update(spel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spel);
        }

        private bool SpelExists(int id) => _context.Spel.Any(e => e.ID == id);
        
        // GET: Spel/Delete/5
        public IActionResult Delete(int? id)
        {
            if(id == null) { return NotFound(); }
            var spel = _context.Spel.FirstOrDefault(m => m.ID == id);
            if (spel == null) { return NotFound(); }
            return View(spel);
        }

        // POST: Spel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var spel = _context.Spel.Find(id);
            _context.Spel.Remove(spel);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout() {
            return Redirect("../Login/");
        }

        public Speler FindSpelerbyID(int id) {
            foreach (Speler speler in _context.Speler) {
                if (speler.Id == id) {
                    return speler;
                }
            }
            return null;

        }

        public async Task<IActionResult> ExitSoloGame() {
            try {
                int spelerID = (int)HttpContext.Session.GetInt32("ID");
                Speler speler = FindSpelerbyID(spelerID);
                int spelID = speler.SpelID;
                //Get the player out of his game
                speler.SpelID = 1;
                _context.Update(speler);
                //Remove old game
                List<Spel> alleSpellen = await _context.Spel.ToListAsync();
                foreach (Spel spel in alleSpellen) {
                    if (spel.ID == spelID) {
                        _context.Remove(spel);
                    }
                }
                await _context.SaveChangesAsync();
                return Redirect("../Login/Menu");
            }
            catch {
                return Redirect("../Login");
            }
            
        }

        public async Task<IActionResult> EditOmschrijving(string oudedef, string omschrijving) {
            if(omschrijving != null && omschrijving != "") {
                List<Spel> alleSpellen = await _context.Spel.ToListAsync();
                Spel spel = alleSpellen.FirstOrDefault(s => s.Omschrijving == oudedef);
                spel.Omschrijving = omschrijving;
                _context.Update(spel);
                await _context.SaveChangesAsync();             
            }
            return Redirect("../Login/Menu");
        }

        public async Task<IActionResult> ExitGame() {
            int spelerID = (int)HttpContext.Session.GetInt32("ID");
            Speler speler = FindSpelerbyID(spelerID);
            List<Spel> alleSpellen = await _context.Spel.ToListAsync();
            Spel spel = alleSpellen.FirstOrDefault(s => s.ID == speler.SpelID);
            foreach (var sp in spel.Spelers) {
                sp.SpelID = 1;
                _context.Update(sp);
            }
            await _context.SaveChangesAsync();
            return Redirect("../Login/Menu");
        }

        public async Task<IActionResult> Pass() {
            int spelerID = (int)HttpContext.Session.GetInt32("ID");
            Speler speler = FindSpelerbyID(spelerID);
            List<Spel> alleSpellen = await _context.Spel.ToListAsync();
            Spel spel = alleSpellen.FirstOrDefault(s => s.ID == speler.SpelID);
            spel.Pas();
            await _context.SaveChangesAsync();
            return Redirect("../Login/Menu");
        }

        public async Task<IActionResult> Surrender() {
            int spelerID = (int)HttpContext.Session.GetInt32("ID");
            Speler speler = FindSpelerbyID(spelerID);
            
            List<Spel> alleSpellen = await _context.Spel.ToListAsync();
            Spel spel = alleSpellen.FirstOrDefault(s => s.ID == speler.SpelID);
            if (speler.Kleur == Kleur.Wit) {
                spel.Token = "WhiteSurrenders";
            }
            else if(speler.Kleur == Kleur.Zwart) {
                spel.Token = "BlackSurrenders";
            }
            await _context.SaveChangesAsync();
            return Redirect("../Login/Menu");
        }

    }
}