using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReversiRestApi.Models;

namespace ReversiRestApi.Controllers {
    [Route("api/Reversi")]
    [ApiController]
    public class ReversiController : ControllerBase {
        public List<Spel> Spellen = new List<Spel>() {
            new Spel {Token = "test"}
        };


        // GET: api/Reversi/Token
        [HttpGet("{Token}")]
        public ActionResult<SpelComponenten> Get(string token) {
            Spel spel = new Spel();
            foreach (Spel item in Spellen) {
                if (token == item.Token) {
                    spel = item;
                }
            }

            int[][] bord = new int[8][];
            for (int i = 0; i <= 7; i++) {
                bord[i] = new int[8];
                for (int j = 0; j <= 7; j++) {
                    if (spel.Bord[i, j] == Kleur.Zwart) {
                        bord[i][j] = 2;
                    }
                    else if (spel.Bord[i, j] == Kleur.Wit) {
                        bord[i][j] = 1;
                    }
                    else bord[i][j] = 0;
                }
            }

            //Return type
            SpelComponenten sc = new SpelComponenten();
            sc.Id = spel.ID;
            sc.Token = spel.Token;

            sc.Bord = bord;
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
    }

}
    

