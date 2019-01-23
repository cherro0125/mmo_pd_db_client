using System.Linq;
namespace mmo_pd_db_client.Repository.Stat
{
    public class StatRepository : BaseRepository<MmoContext,STATYSTYKI>, IStatRepository
    {
        public STATYSTYKI GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}