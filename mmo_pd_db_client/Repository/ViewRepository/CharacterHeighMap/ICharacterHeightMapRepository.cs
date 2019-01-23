using System.Linq;

namespace mmo_pd_db_client.Repository.ViewRepository.CharacterHeighMap
{
    public interface ICharacterHeightMapRepository
    {
        IQueryable<POSTACIE_WYSOKOSC_MAPA> GetAll();
    }
}