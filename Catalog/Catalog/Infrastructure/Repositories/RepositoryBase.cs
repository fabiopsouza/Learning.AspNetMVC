using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Catalog.Models;

namespace Catalog.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IDisposable where T : class
    {
        protected ApplicationDbContext Ctx = new ApplicationDbContext();

        public virtual List<T> Get()
        {
            return Ctx.Set<T>().ToList();
        }

        public virtual T GetById(int id)
        {
            return Ctx.Set<T>().Find(id);
        }

        public virtual void Create(T obj)
        {
            Ctx.Set<T>().Add(obj);
            Ctx.SaveChanges();
        }

        public virtual void Edit(T obj)
        {
            Ctx.Entry(obj).State = EntityState.Modified;
            Ctx.SaveChanges();
        }

        public virtual void Delete(T obj)
        {
            Ctx.Entry(obj).State = EntityState.Deleted;
            Ctx.SaveChanges();
        }

        public void Dispose()
        {
            Ctx.Dispose();
        }
    }
}