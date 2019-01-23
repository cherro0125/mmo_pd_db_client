using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace mmo_pd_db_client.Repository
{

        public interface IBaseRepository<T> where T : class
        {

            IQueryable<T> GetAll();
            IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
            void Add(T entity);
            void Delete(T entity);
            void Edit(T entity);
            void Save();
        }
    

    
}