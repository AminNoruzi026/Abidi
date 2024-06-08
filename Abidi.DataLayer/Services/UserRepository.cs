using Abidi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Context;
using Abidi.DataLayer.Repositories;

namespace Abidi.DataLayer.Services
{
    public class UserRepository : BaseRepository<User>
    {
        private AbidiContext db;

        public UserRepository(AbidiContext context) : base(context)
        {
            db = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool IsExistUser(string username, string password)
        {
            return db.Users.Any(p => p.Username == username && p.Password == password);
        }
    }
}
