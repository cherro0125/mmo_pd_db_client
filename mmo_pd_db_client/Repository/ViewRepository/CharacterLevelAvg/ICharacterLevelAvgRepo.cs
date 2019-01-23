using System.Linq;

namespace mmo_pd_db_client.Repository.ViewRepository.CharacterLevelAvg
{
    public interface ICharacterLevelAvgRepo
    {
        IQueryable<POSTACIE_LEVEL_AVG> GetAll();
    }
}