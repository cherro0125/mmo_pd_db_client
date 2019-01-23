using System.Linq;

namespace mmo_pd_db_client.Repository.Look
{
    public class LookRepository : BaseRepository<Entities1,WYGLAD>, ILookRepository
    {
        public WYGLAD GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}