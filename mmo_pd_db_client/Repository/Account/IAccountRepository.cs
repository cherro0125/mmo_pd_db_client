using System.Collections.Generic;

namespace mmo_pd_db_client.Repository.Account
{
    public interface IAccountRepository
    {
        KONTA GetById(int id);

    }
}