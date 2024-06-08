using Abidi.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abidi.DataLayer.Context;

namespace Abidi.DataLayer.Services
{
    public class PersonFileRepository :BaseRepository<PersonFile>
    {
        private AbidiContext db;

        public PersonFileRepository(AbidiContext context) : base(context)
        {
            db = context;
        }

        public IQueryable<string> GetFileFormatById(int?  id)
        {
            return db.PersonFiles.Where(p => p.FileId == id).Select(p=>p.FileFormat);
        }

        public IQueryable<string> GetFileNameById(int? id)
        {
            return db.PersonFiles.Where(p => p.FileId == id).Select(p => p.FileName);
        }

    }
}
