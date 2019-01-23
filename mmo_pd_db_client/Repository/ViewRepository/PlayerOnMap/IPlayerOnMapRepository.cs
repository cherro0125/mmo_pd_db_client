using System.Linq;

namespace mmo_pd_db_client.Repository.ViewRepository.PlayerOnMap
{
    public interface IPlayerOnMapRepository
    {
        IQueryable<GRACZE_NA_MAPACH> GetAll();
    }
}