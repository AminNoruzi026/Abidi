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
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int personId);
        bool InsertPerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool DeletePerson(int personId);
        bool IsExistPerson(string personalcode, string nationalcode);
        void Save();
    }
}
