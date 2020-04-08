using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Pers;

namespace Lucru_Fisier
{
    public class FisierPersoana : IPersoana
    {
        private const int PAS = 10;
        string NumeFisier { get; set; }

        public FisierPersoana(string numeFisier)
        {
            NumeFisier = numeFisier;
            Stream sFisier = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisier.Close();
        }

        public void addPersoana(Persoana p)
        {
            try
            {
                using (StreamWriter swFisier = new StreamWriter(NumeFisier, true))
                {
                    swFisier.WriteLine(p.afisare());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {
            Persoana[] persoane = new Persoana[PAS];

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrPersoane = 0;

                    //citeste cate o linie si creaza un obiect de tip Carte pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        persoane[nrPersoane++] = new Persoana(line);
                        if (nrPersoane == PAS)
                        {
                            Array.Resize(ref persoane, nrPersoane + PAS);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return persoane;
        }
    }
}
