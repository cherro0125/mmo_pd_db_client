using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
namespace mmo_pd_db_client.Repository.BaseStatistics
{
    public class BaseStatisticsRepository : BaseRepository<Entities1,BAZOWE_STATYSTYKI>, IBaseStatisticsRepository
    {
        public BAZOWE_STATYSTYKI GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}