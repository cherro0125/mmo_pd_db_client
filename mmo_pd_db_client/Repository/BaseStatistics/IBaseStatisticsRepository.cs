using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.BaseStatistics
{
    public interface IBaseStatisticsRepository
    {
        BAZOWE_STATYSTYKI GetById(int id);
        IQueryable<BAZOWE_STATYSTYKI> GetAll();
        IQueryable<BAZOWE_STATYSTYKI> FindBy(Expression<Func<BAZOWE_STATYSTYKI, bool>> predicate);
        void Add(BAZOWE_STATYSTYKI entity);
        void Delete(BAZOWE_STATYSTYKI entity);
        void Edit(BAZOWE_STATYSTYKI entity);
        void Save();

    }
}