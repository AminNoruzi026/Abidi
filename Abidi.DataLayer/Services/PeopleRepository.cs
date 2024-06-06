using Abidi.DataLayer;
using Abidi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Repositories;

namespace Abidi.DataLayer.Services
{
    public class PeopleRepository : IPeopleRepository
    {
        private AbidiContext db;

        public PeopleRepository(AbidiContext context)
        {
            this.db = context;
        }

        public bool DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool DeletePerson(int personId)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        public Person GetPersonById(int personId)
        {
            throw new NotImplementedException();
        }

        public bool InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
