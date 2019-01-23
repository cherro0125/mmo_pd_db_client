using System.Linq;

namespace mmo_pd_db_client.Repository
{
    public class SkillRepository : BaseRepository<MmoContext,UMIEJETNOSCI>, ISkillRepository
    {
        public UMIEJETNOSCI GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}