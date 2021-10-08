using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Models {
    public class Speler {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public Kleur Kleur { get; set; }

        public Speler(Kleur kleur) {
            this.Kleur = kleur;
        }
    }
}
