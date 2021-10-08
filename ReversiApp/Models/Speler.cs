using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiApp.Models {
    public class Speler {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Naam { get; set; }

        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
        public string Token { get; set; }
        public Kleur Kleur { get; set; }

        public int SpelID { get; set; }
        public Spel Spel { get; set; }
        public Speler() {

        }
    }
}
