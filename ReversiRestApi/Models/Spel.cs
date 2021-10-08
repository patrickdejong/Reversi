using ReversiRestApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReversiRestApi.Models {
    public class Spel : ISpel{


        public int ID { get; set; }
        public string Omschrijving { get; set; }
        public string Token { get; set; }
        public ICollection<Speler> Spelers { get; set; }
        public Kleur AandeBeurt { get; set; }
        [NotMapped]
        public Kleur[,] Bord { get; set; }
        

        public Spel() {
            //Set Game ID
            Random rnd = new Random();
            ID = rnd.Next(1, 9999999);

            Omschrijving = "Het leukste spel medemogelijk gemaakt door pizza";
            Token = rnd.Next(1, 9999999).ToString();

            //Set players
            Spelers = new List<Speler>();
            Spelers.Add(new Speler(Kleur.Wit));
            Spelers.Add(new Speler(Kleur.Zwart));

            //Set starting player
            AandeBeurt = Kleur.Zwart;

            //Setup bord
            Bord = new Kleur[8,8];
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    Bord[y, x] = Kleur.Geen;
                }
            }
            Bord[3, 3] = Kleur.Wit;
            Bord[4, 4] = Kleur.Wit;
            Bord[3, 4] = Kleur.Zwart;
            Bord[4, 3] = Kleur.Zwart;

        }

        public bool ZetMogelijk(int rijZet, int kolomZet) {
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
            bool ZetKan = false;
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    if (ZetMogelijk(y, x)) {
                        ZetKan = true;
                    }
                }
            }
            if (AandeBeurt == Kleur.Wit) {
                AandeBeurt = Kleur.Zwart;
            }
            else {
                AandeBeurt = Kleur.Wit;
            }
            for (int y = 0; y < 8; y++) {
                for (int x = 0; x < 8; x++) {
                    if (ZetMogelijk(y, x)) {
                        ZetKan = true;
                    }
                }
            }
            return !ZetKan;
        }

        public bool DoeZet(int psX, int psY) {
            Kleur huidigeSpeler = AandeBeurt;
            Kleur tegenSpeler;
            if(AandeBeurt == Kleur.Zwart) {
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
            else if(!ZetMogelijk(psX, psY)) {
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
                    if(Bord[psX + 1,psY] == tegenSpeler ) {
                        bool search = true;
                        for (int i = psX + 2; i <=7; i++) {
                            if (search) {
                                if (Bord[i, psY] == Kleur.Geen) {
                                    search = false;
                                }
                                if (Bord[i, psY] == huidigeSpeler) {
                                    search = false;
                                    for (int j = psX; j <= i ; j++) {
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
                        for (int i = 2; psX - i >= 0 && psY + i <=7; i++) {
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
                        for (int i = 2; psX - i >= 0 && psY - i >=0; i++) {
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
                        for (int i = 2; psX + i <=7 && psY - i >=0; i++) {
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
                                if (Bord[psX+i, psY+i] == huidigeSpeler) {
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
            if (AandeBeurt == Kleur.Wit) {
                AandeBeurt = Kleur.Zwart;
            }
            else {
                AandeBeurt = Kleur.Wit;
            }
            return v;
        }

        public Kleur OverwegendeKleur() {
            int wit = 0;
            int zwart = 0;
            foreach (var kleur in Bord) {
                if (kleur == Kleur.Wit) {
                    wit++;
                }
                else if(kleur == Kleur.Zwart) {
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
