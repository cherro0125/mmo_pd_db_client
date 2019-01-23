using System.Collections.Generic;
using System.Linq;

namespace mmo_pd_db_client.Repository.Account
{
    public class AccountRepository : BaseRepository<MmoContext,KONTA>, IAccountRepository
    {
        public KONTA GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }


  
    }
}