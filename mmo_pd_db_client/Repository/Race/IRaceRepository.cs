using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Race
{
    public interface IRaceRepository
    {
        RASY GetById(int id);
        IQueryable<RASY> GetAll();
        IQueryable<RASY> FindBy(Expression<Func<RASY, bool>> predicate);
        void Add(RASY entity);
        void Delete(RASY entity);
        void Edit(RASY entity);
        void Save();
    }
}