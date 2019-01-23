using System.Linq;

namespace mmo_pd_db_client.Repository.Character
{
    public class CharacterRepository : BaseRepository<MmoContext,POSTACIE>, ICharacterRepository
    {
        public POSTACIE GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}