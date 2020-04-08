using System;
using Carte_Biblio;
using Pers;
using Lucru_Fisier;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Program
    {
        public const int MAX = 5;
        static void Main(string[] args)
        {
            Persoana[] persoane = new Persoana[MAX];
            Carte[] carti = new Carte[MAX];
            int nrCarti=0, nrPersoane=0;

            string optiune;
            do
            {
                Console.Clear();
                Console.WriteLine("A. Adaugare carte");
                Console.WriteLine("B. Cautare carte");
		Console.WriteLine("C. Editare");
                Console.WriteLine("D. Afisare carti");
                Console.WriteLine("E. Adaugare persoana care imprumuta");
                Console.WriteLine("F. Afiseaza persoanele care au imprumutat carti");
		Console.WriteLine("E. Detalii student");
                Console.WriteLine("X. Exit");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {
                    case "A":
                        Carte c = CitireCarte();
                        carti[nrCarti++] = c;
                        break;
                    case "B":
                        Console.WriteLine("Spune cartea de cautat(titlu si autor");
                        string _titlu = Console.ReadLine();
                        string _autor = Console.ReadLine();
                        int ok = 0;
                        foreach (var car in carti)
                        {
                            if (car.Autor == _autor && car.Titlu == _titlu)
                            {
                                Console.WriteLine(car.afisare());
                                ok = 1;
                            }
                        }
                        if (ok == 0)
                            Console.WriteLine("Carte negasita");

                        else
                            Console.WriteLine("Cartea nu este disponibila.");
                        break;
                    case "C":
                        Console.WriteLine("Scrie titlul cartii de editat:");
                        string nume = Console.ReadLine();
                        Console.WriteLine("Scrie autorul cartii de editat:");
                        string aut = Console.ReadLine();
                        ok = 0;
                        foreach (var car in carti)
                        { 
                            if (car.Autor==aut && car.Titlu == nume)
                            {
                                Console.WriteLine("Scrieti noul titlu");
                                _titlu = Console.ReadLine();
                                Console.WriteLine("Scrieti noul autor");
                                _autor = Console.ReadLine();
                                car.Titlu = nume;
                                car.Autor = aut;
                                ok = 1;
                            }
                        }
                        if(ok==0)
                            Console.WriteLine("Carte negasita");
                        break;
                        
                    case "D":
                        Persoana ps = CitirePersoana();
                        Console.WriteLine("Spune cartea de imprumutat(titlu si autor");
                        _titlu = Console.ReadLine();
                        _autor = Console.ReadLine();
                        if (CautaCarte(_titlu, _autor, carti))
                        {
                            
                            ps.CartiImprumutate++;
                            persoane[nrPersoane++] = ps;
                        }
                        else
                            Console.WriteLine("Ne pare rau, cartea nu este disponibila sau ati depasit numarut maxim de carti imprumutate.");

                        break;
                    case "E":
                        AfisareCarti(carti, nrCarti);
                        break;
                    case "F":
                        AfisarePersoane(persoane, nrPersoane);
                        break;
		    case "G":
                        Console.WriteLine("Ghetes Robert Denis");
                        Console.WriteLine("Calculatoare, anul 2");
			Console.WriteLine("Grupa 3121A");
			break;
                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            
            Console.ReadLine();
        }

        public static void AfisareCarti(Carte[] carti, int nrCarti)
        {
            Console.WriteLine("Cartile sunt:");
            for (int i = 0; i < nrCarti; i++)
                Console.WriteLine(carti[i].afisare());
        }

        public static void AfisarePersoane(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele sunt:");
            for (int i = 0; i < nrPersoane; i++)
            {
                Console.WriteLine(persoane[i].afisare());
            }
        }

        public static bool CautaCarte(string _titlu, string _autor, Carte[] carti)
        {
            foreach (var c in carti)
            {
                if(c.Titlu == _titlu && c.Autor == _autor)
                {
                    if (c.NumarExemplare > 0)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
            return false;
        }

        public static Persoana CitirePersoana()
        {
            Console.WriteLine("Introduceti numele");
            string nume = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string prenume = Console.ReadLine();

            Persoana p = new Persoana(nume, prenume);

            return p;
        }

        public static Carte CitireCarte()
        {
            Console.WriteLine("Introduceti titlul:");
            string titlu = Console.ReadLine();

            Console.WriteLine("Introduceti autorul:");
            string autor = Console.ReadLine();

            Console.WriteLine("Introduceti numarul de exemplare disponibile:");
            int numar = Convert.ToInt32(Console.ReadLine());

            Carte c = new Carte(titlu, autor, numar);

            return c;
        }

    }
}
