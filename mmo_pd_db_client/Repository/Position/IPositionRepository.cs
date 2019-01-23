using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Position
{
    public interface IPositionRepository
    {
        POZYCJE GetById(int id);
        IQueryable<POZYCJE> GetAll();
        IQueryable<POZYCJE> FindBy(Expression<Func<POZYCJE, bool>> predicate);
        void Add(POZYCJE entity);
        void Delete(POZYCJE entity);
        void Edit(POZYCJE entity);
        void Save();
    }
}