using System.Linq;

namespace mmo_pd_db_client.Repository.CharacterClass
{
    public class CharacterClassRepository : BaseRepository<MmoContext,KLASY_POSTACI>, ICharacterClassRepository
    {
        public KLASY_POSTACI GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}