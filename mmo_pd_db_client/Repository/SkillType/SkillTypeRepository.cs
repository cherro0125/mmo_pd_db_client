using System.Linq;
namespace mmo_pd_db_client.Repository.SkillType
{
    public class SkillTypeRepository : BaseRepository<Entities1,TYPY_UMIEJETNOSCI>
    {
        public TYPY_UMIEJETNOSCI GetById(int id)
        {
            var query = GetAll().FirstOrDefault(x => x.ID == id);
            return query;
        }
    }
}