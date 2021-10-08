using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReversiApp.Models {
    public class Spel : ISpel {

        [Key]
        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public Kleur AandeBeurt { get; set; }
        [NotMapped]
        public Kleur[,] Bord { get; set; }
        public string JsonBord { get; set; }

        public ICollection<Speler> Spelers { get; set; }

        public Spel() {
            //Set Game    
            Omschrijving = "Het leukste spel medemogelijk gemaakt door pizza";
            Random rnd = new Random();
            Token = rnd.Next(1, 9999999).ToString();

            //Set players
            Spelers = new List<Speler>();
            /*var Player1 = new Speler();
            Player1.Kleur = Kleur.Zwart;
            var Player2 = new Speler();
            Player2.Kleur = Kleur.Wit;
            Spelers.Add(Player1);
            Spelers.Add(Player2);*/

            //Set starting player
            AandeBeurt = Kleur.Zwart;

            //Setup bord
            Bord = new Kleur[8, 8];
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    Bord[y, x] = Kleur.Geen;
                }
            }
            Bord[3, 3] = Kleur.Wit;
            Bord[4, 4] = Kleur.Wit;
            Bord[3, 4] = Kleur.Zwart;
            Bord[4, 3] = Kleur.Zwart;

            SerialiseBord();
        }

        public void SerialiseBord() {
            JsonBord = JsonConvert.SerializeObject(Bord);
        }

        public void DeserialiseBord() {
            Bord = JsonConvert.DeserializeObject<Kleur[,]>(JsonBord);
        }

        public bool ZetMogelijk(int rijZet, int kolomZet) {
            DeserialiseBord();
            bool returnvalue = false;
            if (OpBord(rijZet, kolomZet)) {
                if (Bord[rijZet, kolomZet].Equals(Kleur.Geen)) {
                    for (int verschilRij = -1; verschilRij <= 1; verschilRij++) {
                        for (int verschilKolom = -1; verschilKolom <= 1; verschilKolom++) {
                            if (!(verschilRij == 0 && verschilKolom == 0) && KanGewisseldWorden(rijZet, kolomZet, verschilRij, verschilKolom)) {
                                returnvalue = true;
                            }
                        }
                    }
                }
            }
            return returnvalue;
        }
        public bool KanGewisseldWorden(int rijZet, int kolomZet, int verschilRij, int verschilKolom) {
            DeserialiseBord();
            int rij = rijZet + verschilRij;
            int kolom = kolomZet + verschilKolom;
            bool returnValue = true;

            while (rij >= 0 && rij < 8 && kolom >= 0 && kolom < 8 && !Bord[rij, kolom].Equals(AandeBeurt) && Bord[rij, kolom] != Kleur.Geen) {
                rij += verschilRij;
                kolom += verschilKolom;
            }

            if (rij < 0 || rij >= 8 || kolom < 0 || kolom >= 8 || !Bord[rij, kolom].Equals(AandeBeurt) || ((rij - verschilRij == rijZet && kolom - verschilKolom == kolomZet) && (Bord[rij, kolom] != Kleur.Geen))) {
                returnValue = false;
            }

            return returnValue;
        }
        public bool OpBord(int rijZet, int kolomZet) {
            return (rijZet >= 0 && rijZet < 8 && kolomZet >= 0 && kolomZet < 8);
        }

        public bool Afgelopen() {
            //Check if current Aandebeurt player can move
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    if (ZetMogelijk(y, x)) {
                        return false;
                    }
                }
            }
            //Swap Player
            if (AandeBeurt == Kleur.Wit) {
                AandeBeurt = Kleur.Zwart;
            }
            else {
                AandeBeurt = Kleur.Wit;
            }
            //Check if current Aandebeurt player can move
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    if (ZetMogelijk(y, x)) {
                        return false;
                    }
                }
            }
            //All players cannot move by this point
            Kleur winnaarKleur = OverwegendeKleur();
            if(winnaarKleur == Kleur.Wit) {
                Token = "WitWint";
            }
            else if(winnaarKleur == Kleur.Zwart) {
                Token = "ZwartWint";
            }
            else {
                Token = "Tie";
            }
            return true; //The game has ended so this is true
        }

        public bool DoeZet(int psX, int psY) {
            DeserialiseBord();
            Kleur huidigeSpeler = AandeBeurt;
            Kleur tegenSpeler;
            if (AandeBeurt == Kleur.Zwart) {
                tegenSpeler = Kleur.Wit;
            }
            else {
                tegenSpeler = Kleur.Zwart;
            }

            //Check if position is on the board
            if (psX > 7 || psX < 0 || psY > 7 || psY < 0) {
                return false;
            }
            //Check whether the move is allowed
            else if (!ZetMogelijk(psX, psY)) {
                return false;
            }
            //Execute move
            else {
                //Place new stone
                Kleur kleurBeurt = AandeBeurt;
                if (kleurBeurt == Kleur.Zwart) {
                    Bord[psX, psY] = Kleur.Zwart;
                }
                else {
                    Bord[psX, psY] = Kleur.Wit;
                }
                //Replace stones in between
                //Check north
                if (psX > 1) {
                    if (Bord[psX - 1, psY] == tegenSpeler) {
                        bool search = true;
                        for (int i = psX - 2; i >= 0; i--) {
                            if (search) {
                                if (Bord[i, psY] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[i, psY] == huidigeSpeler) {
                                    search = false;
                                    for (int j = psX; j >= i; j--) {
                                        Bord[j, psY] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check south
                if (psX < 6) {
                    if (Bord[psX + 1, psY] == tegenSpeler) {
                        bool search = true;
                        for (int i = psX + 2; i <= 7; i++) {
                            if (search) {
                                if (Bord[i, psY] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[i, psY] == huidigeSpeler) {
                                    search = false;
                                    for (int j = psX; j <= i; j++) {
                                        Bord[j, psY] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check East
                if (psY < 6) {
                    if (Bord[psX, psY + 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = psY + 2; i <= 7; i++) {
                            if (search) {
                                if (Bord[psX, i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX, i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = psY; j <= i; j++) {
                                        Bord[j, psX] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check West
                if (psY > 1) {
                    if (Bord[psX, psY - 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = psY - 2; i >= 0; i--) {
                            if (search) {
                                if (Bord[psX, i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX, i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = psY; j >= i; j--) {
                                        Bord[psX, j] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check North-East
                if (psX > 1 && psY < 6) {
                    if (Bord[psX - 1, psY + 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = 2; psX - i >= 0 && psY + i <= 7; i++) {
                            if (search) {
                                if (Bord[psX - i, psY + i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX - i, psY + i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = 0; j <= i; j++) {
                                        Bord[psX - j, psY + j] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check North-West
                if (psX > 1 && psY > 1) {
                    if (Bord[psX - 1, psY - 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = 2; psX - i >= 0 && psY - i >= 0; i++) {
                            if (search) {
                                if (Bord[psX - i, psY - i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX - i, psY - i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = 0; j <= i; j++) {
                                        Bord[psX - j, psY - j] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check South-West
                if (psX < 6 && psY > 1) {
                    if (Bord[psX + 1, psY - 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = 2; psX + i <= 7 && psY - i >= 0; i++) {
                            if (search) {
                                if (Bord[psX + i, psY - i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX + i, psY - i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = 0; j <= i; j++) {
                                        Bord[psX + j, psY - j] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                //Check South-East
                if (psX < 6 && psY < 6) {
                    if (Bord[psX + 1, psY + 1] == tegenSpeler) {
                        bool search = true;
                        for (int i = 2; i <= 7; i++) {
                            if (search) {
                                if (Bord[psX + i, psY + i] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[psX + i, psY + i] == huidigeSpeler) {
                                    search = false;
                                    for (int j = 0; j <= i; j++) {
                                        Bord[psX + j, psY + j] = huidigeSpeler;
                                    }
                                }
                            }
                        }
                    }
                }

                AandeBeurt = tegenSpeler;
                SerialiseBord();
                return true;
            }
        }

        public bool Pas() {
            bool v = false;
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    if (!ZetMogelijk(y, x)) {
                        v = true;
                    }
                }
            }
            if (v) {
                if (AandeBeurt == Kleur.Wit) {
                    AandeBeurt = Kleur.Zwart;
                }
                else {
                    AandeBeurt = Kleur.Wit;
                }
            }
            return v;
        }

        public Kleur OverwegendeKleur() {
            DeserialiseBord();
            int wit = 0;
            int zwart = 0;
            foreach (var kleur in Bord) {
                if (kleur == Kleur.Wit) {
                    wit++;
                }
                else if (kleur == Kleur.Zwart) {
                    zwart++;
                }
            }

            if (wit > zwart) {
                return Kleur.Wit;
            }
            else if (zwart > wit) {
                return Kleur.Zwart;
            }
            else {
                return Kleur.Geen;
            }
        }
    }
}
