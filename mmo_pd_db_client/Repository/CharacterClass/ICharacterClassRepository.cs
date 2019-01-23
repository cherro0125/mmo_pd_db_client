using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.CharacterClass
{
    public interface ICharacterClassRepository
    {
        KLASY_POSTACI GetById(int id);
        IQueryable<KLASY_POSTACI> GetAll();
        IQueryable<KLASY_POSTACI> FindBy(Expression<Func<KLASY_POSTACI, bool>> predicate);
        void Add(KLASY_POSTACI entity);
        void Delete(KLASY_POSTACI entity);
        void Edit(KLASY_POSTACI entity);
        void Save();
    }
}