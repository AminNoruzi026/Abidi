using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Models;
using Abidi.DataLayer.Services;

namespace Abidi.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        AbidiContext db = new AbidiContext();

        private UserRepository _userRepository;
        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(db);
                }
                return _userRepository;
            }
        }

        private PersonRepository _personRepository;
        public PersonRepository PersonRepository
        {
            get
            {
                if (_personRepository == null)
                {
                    _personRepository = new PersonRepository(db);
                }
                return _personRepository;
            }
        }

        private PersonFileRepository _personFileRepository;
        public PersonFileRepository PersonFileRepository
        {
            get
            {
                if (_personFileRepository == null)
                {
                    _personFileRepository = new PersonFileRepository(db);
                }
                return _personFileRepository;
            }
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
