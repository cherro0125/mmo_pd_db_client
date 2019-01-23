using mmo_pd_db_client.Repository;
using mmo_pd_db_client.Repository.Account;
using mmo_pd_db_client.Repository.BaseStatistics;
using mmo_pd_db_client.Repository.Character;
using mmo_pd_db_client.Repository.CharacterClass;
using mmo_pd_db_client.Repository.Look;
using mmo_pd_db_client.Repository.Map;
using mmo_pd_db_client.Repository.Position;
using mmo_pd_db_client.Repository.Race;
using mmo_pd_db_client.Repository.SkillCharacterRepository;
using mmo_pd_db_client.Repository.SkillType;
using mmo_pd_db_client.Repository.Stat;
using mmo_pd_db_client.Repository.ViewRepository.CharacterHeighMap;
using mmo_pd_db_client.Repository.ViewRepository.CharacterLevelAvg;
using mmo_pd_db_client.Repository.ViewRepository.PlayerOnMap;

namespace mmo_pd_db_client.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
    

        public IAccountRepository AccountRepository { get; }
        public IBaseStatisticsRepository BaseStatisticsRepository { get; }
        public ICharacterRepository CharacterRepository { get; }
        public ICharacterClassRepository CharacterClassRepository { get; }
        public ILookRepository LookRepository { get; }
        public IMapRepository MapRepository { get; }
        public IPositionRepository PositionRepository { get; }
        public IRaceRepository RaceRepository { get; }
        public ISkillRepository SkillRepository { get; }
        public ISkillCharacterRepository SkillCharacterRepository { get; }
        public ISkillTypeRepository SkillTypeRepository { get; }
        public IStatRepository StatRepository { get; }
        public ICharacterHeightMapRepository CharacterHeightMapRepository { get; }
        public ICharacterLevelAvgRepo CharacterLevelAvg { get; }
        public IPlayerOnMapRepository PlayerOnMapRepository { get; }

        public UnitOfWork()
        {
            AccountRepository = new AccountRepository();
            BaseStatisticsRepository = new BaseStatisticsRepository();
            CharacterRepository = new CharacterRepository();
            CharacterClassRepository = new CharacterClassRepository();
            LookRepository = new LookRepository();
            MapRepository = new MapRepository();
            PositionRepository = new PositionRepository();
            RaceRepository = new RaceRepository();
            SkillRepository = new SkillRepository();
            SkillCharacterRepository = new SkillCharacterRepository();
            SkillTypeRepository = new SkillTypeRepository();
            StatRepository = new StatRepository();
            CharacterHeightMapRepository = new CharacterHeighMapRepository();
            CharacterLevelAvg = new CharacterLevelAvgRepo();
            PlayerOnMapRepository = new PlayerOnMapRepository();
        }

        public void Dispose()
        {
            
        }
    }
}