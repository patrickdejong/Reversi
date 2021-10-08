using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReversiRestApi.Models {
    public class SpelComponenten {
        public int Id { get; set; }
        public string Token { get; set; }
        public string TokenWhite { get; set; }
        public string TokenBlack { get; set; }
        public int[][] Bord { get; set; }
        public int AandeBeurt { get; set; }
    }
}
