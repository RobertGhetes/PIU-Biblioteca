using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pers;

namespace Lucru_Fisier
{
    public interface IPersoana
    {
        void addPersoana(Persoana p);

        Persoana[] GetPersoane(out int nrPersoane);

    }
}
