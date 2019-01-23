using System.Linq;

namespace mmo_pd_db_client.Repository.Race
{
    public class RaceRepository : BaseRepository<Entities1,RASY>, IRaceRepository
    {
        public RASY GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}