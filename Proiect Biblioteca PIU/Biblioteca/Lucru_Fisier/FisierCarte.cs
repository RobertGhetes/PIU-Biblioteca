using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Carte_Biblio;

namespace Lucru_Fisier
{
    public class FisierCarte:ICarte
    {
        private const int PAS = 10;
        string NumeFisier { get; set; }

        public FisierCarte(string numeFisier)
        {
            NumeFisier = numeFisier;
            Stream sFisier = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisier.Close();
        }

        public void addCarte(Carte c)
        {
            try
            {
                using (StreamWriter swFisier = new StreamWriter(NumeFisier, true))
                {
                    swFisier.WriteLine(c.afisare());
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

        public Carte[] GetCarti(out int nrCarti)
        {
            Carte[] carti = new Carte[PAS];

            try
            {
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrCarti = 0;

                    //citeste cate o linie si creaza un obiect de tip Carte pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        carti[nrCarti++] = new Carte(line);
                        if (nrCarti == PAS)
                        {
                            Array.Resize(ref carti, nrCarti + PAS);
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

            return carti;
        }
    }
}
