using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository
{
    public interface ISkillRepository
    {
        UMIEJETNOSCI GetById(int id);
        IQueryable<UMIEJETNOSCI> GetAll();
        IQueryable<UMIEJETNOSCI> FindBy(Expression<Func<UMIEJETNOSCI, bool>> predicate);
        void Add(UMIEJETNOSCI entity);
        void Delete(UMIEJETNOSCI entity);
        void Edit(UMIEJETNOSCI entity);
        void Save();
    }
}