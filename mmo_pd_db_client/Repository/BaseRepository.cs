using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mmo_pd_db_client.Repository
{
    public abstract class BaseRepository<C, T> :
        IBaseRepository<T> where T : class where C : DbContext, new()
    {

      
        private C _entities = new C();
        public C Context
        {

            get { return _entities; }
            set { _entities = value; }
        }


        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void Add(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public IQueryable<T> PrepareResults(IQueryable<T> result,
            params Func<IQueryable<T>, IQueryable<T>>[] include)
        {
            if (include.Any())
            {
                result = include.Aggregate(result, (current, inc) => inc(current));
            }

            return result;
        }

    }

}