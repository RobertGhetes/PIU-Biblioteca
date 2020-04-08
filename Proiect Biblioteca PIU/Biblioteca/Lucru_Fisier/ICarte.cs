using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Carte_Biblio;

namespace Lucru_Fisier
{
    public interface ICarte
    {
        void addCarte(Carte c);
        Carte[] GetCarti(out int nrCarti);
    }
}
