using Abidi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abidi.DataLayer.Repositories
{
    public interface IPeopleRepository : IDisposable
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int personId);
        bool InsertPerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(Person person);
        bool DeletePerson(int personId);
        void Save();
    }
}
