using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.SkillType
{
    public interface ISkillTypeRepository
    {
        TYPY_UMIEJETNOSCI GetById(int id);
        IQueryable<UMIEJETNOSCI_POSTAC> GetAll();
        IQueryable<UMIEJETNOSCI_POSTAC> FindBy(Expression<Func<UMIEJETNOSCI_POSTAC, bool>> predicate);
        void Add(UMIEJETNOSCI_POSTAC entity);
        void Delete(UMIEJETNOSCI_POSTAC entity);
        void Edit(UMIEJETNOSCI_POSTAC entity);
        void Save();
    }
}