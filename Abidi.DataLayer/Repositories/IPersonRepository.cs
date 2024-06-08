using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Models;

namespace Abidi.DataLayer.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        bool IsExistPerson(string personalcode, string nationalcode);
        Person GetPersonByFullName(string firstname, string lastname);
        string GetLastNameByNationalCode(string nationalcode);
        Person GetPersonByNationalCode(string nationalcode);
        Person GetPersonByPersonalCode(string personalcode);
        void Save();
    }
}
