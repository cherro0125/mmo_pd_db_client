using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace mmo_pd_db_client.Repository.Account
{
    public interface IAccountRepository 
    {
        KONTA GetById(int id);
        IQueryable<KONTA> GetAll();
        IQueryable<KONTA> FindBy(Expression<Func<KONTA, bool>> predicate);
        void Add(KONTA entity);
        void Delete(KONTA entity);
        void Edit(KONTA entity);
        void Save();

    }
}