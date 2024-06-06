using Abidi.DataLayer.Models;
using Abidi.DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace Abidi.DataLayer
{
    public interface IBaseRepository<T> where T : class, IBaseEntity
    {
        List<T> GetAll();
        int GetCount();
        T Get(int id);
        T Add(T entity);
        T Update(T entity);
        T Delete(int id);
    }
    public abstract class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
         where TEntity : class, IBaseEntity
         where TContext : DbContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }
        public  TEntity Add(TEntity entity)
        {
            //var user = GetCurrentUser();
            entity.InsertDate = DateTime.Now;
            //if (user != null)
            //{
            //    entity.InsertUser = user.username;
            //}
            var ent = entity.GetType().Name;

            context.Set<TEntity>().Add(entity);
             context.SaveChanges();
            return entity;
        }

        public  TEntity Delete(int id)
        {
            var entity =  context.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            entity.IsDeleted = true;
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }

        public  TEntity Get(int id)
        {
            return  context.Set<TEntity>().Find(id);
        }

        public List<TEntity> GetAll()
        {
            return  context.Set<TEntity>().Where(e=>e.IsDeleted == false).OrderByDescending(e=>e.InsertDate).ToList();
        }     
        public int GetCount()
        {
            var entity =  context.Set<TEntity>().Count();

            return entity;
        }
        public  TEntity Update(TEntity entity)
        {
            //var user = GetCurrentUser();
            entity.UpdateDate = DateTime.Now;
            //if (user != null)
            //{
            //    entity.UpdateUser = user.username;
            //}

            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity;
        }
        //public users GetCurrentUser()
        //{
        //    var username = HttpContext.Current.User.Identity.GetUserName();
        //    if (username == null)
        //        return null;
        //    var user = context.Set<users>().FirstOrDefault(u => u.username.Trim().ToLower() == username.Trim().ToLower());
        //    return user;

        //}
    }
}
