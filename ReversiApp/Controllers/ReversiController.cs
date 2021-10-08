using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReversiApp.DAL;
using ReversiApp.Models;

namespace ReversiApp.Controllers {
    [Route("api/Reversi")]
    [ApiController]
    public class ReversiController : ControllerBase {
        private readonly SpelContext _context;
        public ReversiController(SpelContext context) {
            _context = context;
        }

        public List<Spel> Spellen = new List<Spel>() { };


        


        //Get : api/Reversi/Aandebeurt/Token
        [HttpGet("Aandebeurt/{Token}")]
        public ActionResult<int> GetAandebeurt(string token) {
            Spel spel = new Spel();
            foreach (Spel item in Spellen) {
                if (token == item.Token) {
                    spel = item;
                }
            }
            if (spel.AandeBeurt == Kleur.Zwart) {
                return 2;
            }
            else if (spel.AandeBeurt == Kleur.Wit) {
                return 1;
            }
            else {
                return 0;
            }

        }

        //Put : api/Reversi/Zet
        [HttpPut("Zet")]
        public void PutZet([FromBody] Move move) {
            Spel spel = new Spel();
            foreach (Spel item in Spellen) {
                if (move.SpelToken == item.Token) {
                    spel = item;
                }
            }
            if(spel != null) {
                Speler speler = spel.Spelers.First(item => item.Token == move.SpelerToken);
                if (speler != null){
                    if(spel.AandeBeurt == speler.Kleur) {
                        if (move.Pas) {
                            spel.Pas();
                        }
                        else {
                            spel.DoeZet(move.X, move.Y);
                        }
                    }
                }
            }


        }

        // GET: api/Spel/DoeZet/y/x
        [HttpGet("DoeZet/{y}/{x}")]
        public async Task<string> PostZet(int y, int x) {
            bool returnVal = false;
            int loggedInUserId = (int)HttpContext.Session.GetInt32("ID");
            Speler loggedInUser = await _context.Speler.FirstAsync(s => s.Id == loggedInUserId);
            Spel spel = await _context.Spel.FirstAsync(s => s.ID == loggedInUser.SpelID);
            if (spel.AandeBeurt == loggedInUser.Kleur) {
                returnVal = spel.DoeZet(y, x);
            }
            _context.Update(spel);
            await _context.SaveChangesAsync();
            if (returnVal) {
                return "Move (" + y + ", " + x + ") successful";
            }
            else {
                return "Move (" + y + ", " + x + ") failed";
            }
        }
    }

}
    

