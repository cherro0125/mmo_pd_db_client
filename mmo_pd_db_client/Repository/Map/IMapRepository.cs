using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Map
{
    public interface IMapRepository
    {
        MAPY GetById(int id);
        IQueryable<MAPY> GetAll();
        IQueryable<MAPY> FindBy(Expression<Func<MAPY, bool>> predicate);
        void Add(MAPY entity);
        void Delete(MAPY entity);
        void Edit(MAPY entity);
        void Save();
    }
}