using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.SkillType
{
    public interface ISkillTypeRepository
    {
        TYPY_UMIEJETNOSCI GetById(int id);
        IQueryable<TYPY_UMIEJETNOSCI> GetAll();
        IQueryable<TYPY_UMIEJETNOSCI> FindBy(Expression<Func<TYPY_UMIEJETNOSCI, bool>> predicate);
        void Add(TYPY_UMIEJETNOSCI entity);
        void Delete(TYPY_UMIEJETNOSCI entity);
        void Edit(TYPY_UMIEJETNOSCI entity);
        void Save();
    }
}