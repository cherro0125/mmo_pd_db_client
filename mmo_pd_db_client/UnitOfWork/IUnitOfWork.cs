using System;
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
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository AccountRepository { get; }
        IBaseStatisticsRepository BaseStatisticsRepository { get; }
        ICharacterRepository CharacterRepository { get; }
        ICharacterClassRepository CharacterClassRepository { get; }
        ILookRepository LookRepository { get; }
        IMapRepository MapRepository { get; }
        IPositionRepository PositionRepository { get; }
        IRaceRepository RaceRepository { get; }
        ISkillRepository SkillRepository { get; }
        ISkillCharacterRepository SkillCharacterRepository { get; }
        ISkillTypeRepository SkillTypeRepository { get; }
        IStatRepository StatRepository { get; }


        //view repos
        ICharacterHeightMapRepository CharacterHeightMapRepository { get; }
        ICharacterLevelAvgRepo CharacterLevelAvg { get; }
        IPlayerOnMapRepository PlayerOnMapRepository { get; }
    }
}