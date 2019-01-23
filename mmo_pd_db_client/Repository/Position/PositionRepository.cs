using System.Linq;

namespace mmo_pd_db_client.Repository.Position
{
    public class PositionRepository : BaseRepository<MmoContext,POZYCJE>, IPositionRepository
    {
        public POZYCJE GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}