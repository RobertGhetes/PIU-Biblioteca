using System;


namespace Carte_Biblio
{
    public enum TipCarte
    {
        Poezii = 1,
        Manuale = 2,
        Povesti = 3,
    };

    public enum TipCoperta
    {
        tare = 1,
        subtire = 2,
    };
    public class Carte
    {
        public static int IdUltim { get; set; } = 0;
        public int IDCarte { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public int NumarExemplare { get; set; }

        public Carte()
        {
            Titlu = Autor = string.Empty;
            NumarExemplare = 0;
            IdUltim++;
            IDCarte = IdUltim;
        }

        public Carte(string _titlu, string _autor)
        {
            Titlu = _titlu;
            Autor = _autor;
            IdUltim++;
            IDCarte = IdUltim;
        }

        public Carte(string _titlu, string _autor, int _exemplare)
        {
            Titlu = _titlu;
            Autor = _autor;
            NumarExemplare = _exemplare;
            IdUltim++;
            IDCarte = IdUltim;
        }

        public Carte(string linie)
        {
            string[] buff = linie.Split(',');
            Titlu = buff[0];
            Autor = buff[1];
            try
            {
                NumarExemplare = Convert.ToInt32(buff[2]);
            }
            catch (Exception)
            {
                Console.WriteLine("Nu se poate converti.");
            }

            IdUltim++;
            IDCarte = IdUltim;
        }


        public string afisare()
        {
            string s;
            if (NumarExemplare > 0)
                s = string.Format("{3}\t\t \"{0}\" \t\t{1}\t\t{2} exemplare", Titlu , Autor , NumarExemplare,IDCarte);
            else
                s = string.Format("{2}\t\t \"{0}\" \t\t{1}\t\tindisponibil", Titlu, Autor, IDCarte);
            return s;
        }

    }
}