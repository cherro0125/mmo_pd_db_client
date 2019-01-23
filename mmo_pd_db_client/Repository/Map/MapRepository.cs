using System.Linq;

namespace mmo_pd_db_client.Repository.Map
{
    public class MapRepository : BaseRepository<MmoContext,MAPY>, IMapRepository
    {
        public MAPY GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}