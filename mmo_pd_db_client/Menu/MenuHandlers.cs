using mmo_pd_db_client.Manual.DB;
using mmo_pd_db_client.UnitOfWork;

namespace mmo_pd_db_client.Menu
{
    public class MenuHandlers
    {
        private IUnitOfWork _unitOfWork;
        private DbOperation _dbOperation;

        public MenuHandlers()
        {
            _unitOfWork = new UnitOfWork.UnitOfWork();       
            _dbOperation = new DbOperation();            
        }

        #region ManualDB

        public void CreateTables()
        {
            _dbOperation.CreateTables();
        }

        public void DropTables()
        {
            _dbOperation.DropTables();
        }

        public void CreateSequences()
        {
            _dbOperation.CreateSequences();
        }

        public void DropSequences()
        {
            _dbOperation.DropSequences();
        }

        public void CreatePackages()
        {
            _dbOperation.CreatePackages();
        }

        public void DropPackages()
        {
            _dbOperation.DropPackages();
        }

        public void CreateTriggers()
        {
            _dbOperation.CreateTriggers();
        }

        public void DropTriggers()
        {
            _dbOperation.DropTriggers();
        }

        public void CreateViews()
        {
            _dbOperation.CreateViews();       
        }

        public void InsertExampleData()
        {
            _dbOperation.InsertExamplesData();
        }

        public void InsertNonValidData()
        {
            _dbOperation.InsertNotValidData();
        }



        #endregion

        #region ORM

      

        #endregion
    }
}