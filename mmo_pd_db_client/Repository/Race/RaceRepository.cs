using System.Linq;

namespace mmo_pd_db_client.Repository.Race
{
    public class RaceRepository : BaseRepository<MmoContext,RASY>, IRaceRepository
    {
        public RASY GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}