using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Models {
    public class Move {
        public string SpelToken { get; set; }
        public string SpelerToken { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Pas { get; set; }

        public Move(string speltoken) {
            SpelToken = speltoken;
        }
    }
}
