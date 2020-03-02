using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BookStore_DAL.Repository
{
    public class GenericRepositry<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private StoreDbContext context;
        private DbSet<TEntity> dbSet;
        public GenericRepositry()
        {
            this.context = new StoreDbContext();
            this.dbSet = this.context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList<TEntity>();
        }

        public TEntity Get(int id)
        {
            return dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            TEntity entToDel = dbSet.Find(id);
            Delete(entToDel);
        }

        public void Delete(TEntity entToDel)
        {
            if (context.Entry(entToDel).State == EntityState.Detached)
            {
                dbSet.Attach(entToDel);
            }
            dbSet.Remove(entToDel);
        }

        public void Update(TEntity entToUpd)
        {
            dbSet.Attach(entToUpd);
            context.Entry(entToUpd).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}