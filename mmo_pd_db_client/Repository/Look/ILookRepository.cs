using System;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Look
{
    public interface ILookRepository
    {
        WYGLAD GetById(int id);
        IQueryable<WYGLAD> GetAll();
        IQueryable<WYGLAD> FindBy(Expression<Func<WYGLAD, bool>> predicate);
        void Add(WYGLAD entity);
        void Delete(WYGLAD entity);
        void Edit(WYGLAD entity);
        void Save();
    }
}