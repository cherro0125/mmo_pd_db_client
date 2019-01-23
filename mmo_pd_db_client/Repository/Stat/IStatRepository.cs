using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Stat
{
    public interface IStatRepository
    {
        STATYSTYKI GetById(int id);
        IQueryable<STATYSTYKI> GetAll();
        IQueryable<STATYSTYKI> FindBy(Expression<Func<STATYSTYKI, bool>> predicate);
        void Add(STATYSTYKI entity);
        void Delete(STATYSTYKI entity);
        void Edit(STATYSTYKI entity);
        void Save();
    }
}