using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abidi.DataLayer.Repositories
{
    public interface IUserRepository:IDisposable
    {
        bool IsExistUser(string username, string password);
    }
}
