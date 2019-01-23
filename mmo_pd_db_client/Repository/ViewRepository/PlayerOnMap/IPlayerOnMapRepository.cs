namespace mmo_pd_db_client.Repository.ViewRepository.PlayerOnMap
{
    public interface IPlayerOnMapRepository
    {
        GRACZE_NA_MAPACH GetById(int id);
    }
}