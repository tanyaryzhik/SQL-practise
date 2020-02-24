using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace University.DAL.Repositories
{
    public class GenericRepositry<TEntity> where TEntity : class
    {
        internal UniverDbContext context;
        internal DbSet<TEntity> dbSet;
        public GenericRepositry(UniverDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                string includeProperties= "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entToDel = dbSet.Find(id);
            Delete(entToDel);
        }
        public virtual void Delete(TEntity entToDel)
        {
            if (context.Entry(entToDel).State == EntityState.Detached)
            {
                dbSet.Attach(entToDel);
            }
            dbSet.Remove(entToDel);
        }

        public virtual void Update(TEntity entToUpd)
        {
            dbSet.Attach(entToUpd);
            context.Entry(entToUpd).State = EntityState.Modified;
        }
    }
}
