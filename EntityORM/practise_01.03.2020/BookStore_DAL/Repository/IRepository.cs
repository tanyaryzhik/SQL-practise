using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore_DAL.Repository
{
    interface IRepository<TEntity> : IDisposable
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Delete(int id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        void Add(TEntity entity);
        void Save();
    }
}
