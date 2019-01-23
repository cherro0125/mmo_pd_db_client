using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Character
{
    public interface ICharacterRepository
    {
        POSTACIE GetById(int id);
        IQueryable<POSTACIE> GetAll();
        IQueryable<POSTACIE> FindBy(Expression<Func<POSTACIE, bool>> predicate);
        void Add(POSTACIE entity);
        void Delete(POSTACIE entity);
        void Edit(POSTACIE entity);
        void Save();
    }
}