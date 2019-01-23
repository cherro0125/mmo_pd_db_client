using System.Linq;

namespace mmo_pd_db_client.Repository.SkillCharacterRepository
{
    public class SkillCharacterRepository : BaseRepository<MmoContext,UMIEJETNOSCI_POSTAC>, ISkillCharacterRepository
    {
        public UMIEJETNOSCI_POSTAC GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}