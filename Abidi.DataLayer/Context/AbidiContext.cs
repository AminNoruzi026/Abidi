using Abidi.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Models;

namespace Abidi.DataLayer.Context
{
    public class AbidiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Person> People { get; set; }

        public System.Data.Entity.DbSet<Abidi.DataLayer.Models.PersonFile> PersonFiles { get; set; }
    }
}
