using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Models;
using Abidi.DataLayer.Repositories;

namespace Abidi.DataLayer.Services
{
    public class PersonRepository : BaseRepository<Person>
    {
        private AbidiContext db;

        public PersonRepository(AbidiContext context) : base(context)
        {
            db = context;
        }

        public bool IsExistPerson(string personalcode, string nationalcode)
        {
            return !db.People.Any(p => p.PersonalCode == personalcode && p.NationalCode == nationalcode);
        }

        
    }
}
