using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReversiApp.DAL;
using ReversiApp.Models;

namespace ReversiApp.Controllers {
    public class LoginController : Controller {
        private readonly SpelContext _context;

        public LoginController(SpelContext context) {
            _context = context;
        }

        // GET: LoginPage
        [HttpGet]
        public async Task<IActionResult> Index() {
            HttpContext.Session.Clear();
            //var spelContext = _context.Speler.Include(s => s.Spel);
            //return View(await spelContext.ToListAsync());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password) {
            bool validation = false;
            //Check if empty
            if (email == null || password == null) {
                return View("Index");
            }
            //Check if email and password match
            Speler logger = FindSpelerbyEmail(email);
            validation = CheckPassWord(password, logger);
            if (logger == null || validation == false) {
                return Content("Your input was invalid.");
            }
            //If validation is true, login the user :)     
            if (validation) {
                //Set session
                HttpContext.Session.SetInt32("ID", logger.Id);
                HttpContext.Session.SetString("NAME", logger.Naam);
                return RedirectToAction(nameof(Menu));

            }
            return View("Index");
        }

        public async Task<IActionResult> Menu() {
            try {
                int id = (int)HttpContext.Session.GetInt32("ID");
                Speler speler = FindSpelerbyID(id);
                if (speler.SpelID <= 1) {
                    List<Spel> spellenMetEenSpeler = new List<Spel>();
                    List<Spel> alleSpellen = await _context.Spel.ToListAsync();
                    List<Speler> alleSpelers = await _context.Speler.ToListAsync();
                    foreach (Speler sp in alleSpelers) {
                        spellenMetEenSpeler.Add(alleSpellen.Find(s => s.ID == sp.SpelID));
                    }
                    List<Spel> spellenToShow = new List<Spel>();
                    foreach (Spel spel in alleSpellen) {
                        if (spel.ID != 1 && spel.Spelers.Count == 1) {
                            spellenToShow.Add(spel);
                        }
                    }
                    return View(spellenToShow);
                }
                else {
                    return Redirect("../Spel/Spelbord/" + speler.SpelID);
                }
            }
            catch {
                return RedirectToAction(nameof(Index));
            }
        }


        public IActionResult UserDetails(Speler speler) {
            return View(speler);
        }

        // GET: Login/Create
        [HttpGet]
        public IActionResult Create() {
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID");
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Email,Password,SpelID")] Speler speler, string password, string password2) {
            //Do a password quality Check
            if (checkPasswordQuality(password) == false) {
                return Content($"Password was not strong enough. Check if you have applied all requirements.\n\nRequirements (At least):\n- 1 Capital letter\n- 1 Lowercase letter\n- 1 Digit\n- 8 Characters -> ........");
            }
            else {
                //Check if passwords are the same
                if (!password.Equals(password2)) {
                    return Content("Your passwords did not match 100%. Please try again");
                }
                //Check if email is already used (prevents duplicate accounts)
                foreach (Speler x in _context.Speler) {
                    if (x.Email == speler.Email) {
                        return Content("An acccount with this email already exists. Contact the host if you think this is a mistake.");
                    }
                }
                //Save passwords safely
                byte[] salt = GenerateSalt(15);
                speler.Salt = salt;
                byte[] hash = GenerateHash(Encoding.ASCII.GetBytes(password), salt, 15);
                speler.Password = hash;

                //Update Database && Create the player
                if (ModelState.IsValid) {
                    _context.Add(speler);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID", speler.SpelID);
                return View("LoggedIn");
            }
        }

        byte[] GenerateSalt(int length) {
            var bytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider()) {
                rng.GetBytes(bytes);
            }
            return bytes;
        }
        byte[] GenerateHash(byte[] password, byte[] salt, int length) {
            int iterations = 2;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt, iterations)) {
                return deriveBytes.GetBytes(length);
            }
        }


        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(int? id) {
            if (id == null) {
                return NotFound();
            }

            var speler = await _context.Speler.FindAsync(id);
            if (speler == null) {
                return NotFound();
            }
            ViewData["SpelID"] = new SelectList(_context.Spel, "ID", "ID", speler.SpelID);
            return View(speler);
        }


        private bool SpelerExists(int id) => _context.Speler.Any(e => e.Id == id);

        public async Task<IActionResult> ChangePassword(string email, string oldpw, string newpw, string newpw2) {
            Speler logger = await _context.Speler.FirstAsync(s => s.Email == email);
            var HashpasswordInput = GenerateHash(Encoding.ASCII.GetBytes(oldpw), logger.Salt, 15);
            if (logger.Password.SequenceEqual(HashpasswordInput)) {
                if (newpw == newpw2 || newpw.Equals(newpw2)) {
                    byte[] newSalt = GenerateSalt(15);
                    logger.Salt = newSalt;
                    byte[] newHash = GenerateHash(Encoding.ASCII.GetBytes(newpw), newSalt, 15);
                    logger.Password = newHash;
                }
                //Update password
                if (ModelState.IsValid) {
                    _context.Update(logger);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return Content("Oh oh, something went wrong. Make sure all input is valid.");
        }

        public bool checkPasswordQuality(string password) {
            bool hasUC = false;
            bool hasLC = false;
            bool hasDigit = false;
            int amountChars = 0;
            //Check if password is strong enough
            foreach (char x in password) {
                if (Char.IsUpper(x)) {
                    hasUC = true;
                }
                else if (Char.IsLower(x)) {
                    hasLC = true;
                }
                else if (Char.IsDigit(x)) {
                    hasDigit = true;
                }
                amountChars++;
            }
            if (!hasUC || !hasLC || !hasDigit || amountChars < 8) {
                return false;
            }
            else {
                return true;
            }
        }

        public bool CheckPassWord(string password, Speler logger) {
            var HashpasswordInput = GenerateHash(Encoding.ASCII.GetBytes(password), logger.Salt, 15);
            if (logger.Password.SequenceEqual(HashpasswordInput)) {
                return true;
            }
            else {
                return false;
            }
        }

        public Speler FindSpelerbyEmail(string email) {
            foreach (Speler speler in _context.Speler) {
                if (speler.Email == email) {
                    return speler;
                }
            }
            return null;

        }

        public Speler FindSpelerbyID(int id) {
            foreach (Speler speler in _context.Speler) {
                if (speler.Id == id) {
                    return speler;
                }
            }
            return null;
        }

        public IActionResult CreateNewGame() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostCreateNewGame([Bind("Omschrijving, Token, AandeBeurt, JsonBord")] Spel spel) {
            if (ModelState.IsValid) {
                //Add current player to the created game
                int spelerID = (int)HttpContext.Session.GetInt32("ID");
                Speler speler = FindSpelerbyID(spelerID);
                speler.Kleur = Kleur.Zwart;
                spel.Spelers.Add(speler);
                //Save changes
                _context.Add(spel);
                _context.Update(speler);
                await _context.SaveChangesAsync();
                //Return to menu to check if the post was succesfully created   

                return RedirectToAction(nameof(Menu));
            }
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> JoinGame(int spelID) {
            try {
                int spelerID = (int)HttpContext.Session.GetInt32("ID");
                Speler speler = FindSpelerbyID(spelerID);
                List<Spel> alleSpellen = await _context.Spel.ToListAsync();
                Spel spel = alleSpellen.Find(s => s.ID == spelID);
                if (spel == null || speler == null) {
                    return RedirectToAction(nameof(Menu));
                }
                speler.Kleur = Kleur.Wit;
                //Add user to existing game
                spel.Spelers.Add(speler);
                speler.SpelID = spel.ID;
                //Save changes
                _context.Update(spel);
                _context.Update(speler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Menu));
            }
            catch {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}


