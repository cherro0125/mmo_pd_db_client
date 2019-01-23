using System.Linq;

namespace mmo_pd_db_client.Repository.ViewRepository.PlayerOnMap
{
    public class PlayerOnMapRepository : BaseRepository<MmoContext,GRACZE_NA_MAPACH>
    {
        public GRACZE_NA_MAPACH GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}