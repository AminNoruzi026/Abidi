using Abidi.DataLayer.Context;
using Abidi.DataLayer.Models;
using Abidi.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Abidi.DataLayer.Services
{
    public class LoginRepository : ILoginRepository
    {
        private AbidiContext db;

        public LoginRepository(AbidiContext context)
        {
            db = context;
        }
        public bool IsExistUser(string username, string password)
        {
            return db.Users.Any(u => u.Username == username && u.Password == password);
        }
    }
}
