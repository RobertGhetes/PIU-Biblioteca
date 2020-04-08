using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carte_Biblio;

namespace Pers

{

    public class Persoana
    {
        public static int IdUltim { get; set; } = 0;
        public int IDPersoana { get; set; }
        public int CartiImprumutate { get; set; } = 0;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string NumeComplet { get { return Nume + " " + Prenume; } }

        public Persoana()
        {
            Nume = Prenume = string.Empty;
            IdUltim++;
            IDPersoana=IdUltim;
        }

        public Persoana(string _nume, string _prenume)
        {
            Nume = _nume;
            Prenume = _prenume;
            IdUltim++;
            IDPersoana = IdUltim;
        }


        public Persoana(string linie)
        {
            var buff = linie.Split(',');
            IDPersoana = Convert.ToInt32(buff[0]);
            Nume = buff[1];
            Prenume = buff[2];
            CartiImprumutate = Convert.ToInt32(buff[3]);
            IdUltim = IDPersoana;
        }

        public string afisare()
        {
            string s = string.Format("{0}\t\t{1} {2}\t\t{3} carti", IDPersoana, Nume, Prenume, CartiImprumutate);
            return s;
        }
    }
}
