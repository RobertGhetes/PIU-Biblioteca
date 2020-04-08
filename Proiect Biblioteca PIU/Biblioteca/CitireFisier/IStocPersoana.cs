using LibrarieModele;
using System.Collections.Generic;

namespace CitireFisier
{
    //definitia interfetei
    public interface IStocareData
    {
        void AddStudent(Student s);
        Student[] GetStudenti(out int nrStudenti);
    }
}