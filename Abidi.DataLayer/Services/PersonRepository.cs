using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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

        public Person GetPersonByFullName(string firstname, string lastname)
        {
            return db.People.FirstOrDefault(p => p.FirstName == firstname && p.LastName == lastname);
        }


        public Person GetPersonByPersonalCode(string personalcode)
        {
            return db.People.FirstOrDefault(p => p.PersonalCode == personalcode);
        }

        public Person GetPersonByNationalCode(string nationalcode)
        {
            return db.People.FirstOrDefault(p => p.NationalCode == nationalcode);
        }

        public string GetLastNameByNationalCode(string nationalcode)
        {
            return db.People.Where(p => p.NationalCode == nationalcode).Select(p=>p.LastName).FirstOrDefault();
        }

    }
}
