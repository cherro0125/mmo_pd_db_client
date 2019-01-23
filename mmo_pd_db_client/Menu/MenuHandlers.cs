using System;
using System.Threading;
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
            Thread.Sleep(2000);
        }

        public void DropTables()
        {
            _dbOperation.DropTables();
            Thread.Sleep(2000);
        }

        public void CreateSequences()
        {
            _dbOperation.CreateSequences();
            Thread.Sleep(2000);
        }

        public void DropSequences()
        {
            _dbOperation.DropSequences();
            Thread.Sleep(2000);
        }

        public void CreatePackages()
        {
            _dbOperation.CreatePackages();
            Thread.Sleep(2000);
        }

        public void DropPackages()
        {
            _dbOperation.DropPackages();
            Thread.Sleep(2000);
        }

        public void CreateTriggers()
        {
            _dbOperation.CreateTriggers();
            Thread.Sleep(2000);
        }

        public void DropTriggers()
        {
            _dbOperation.DropTriggers();
            Thread.Sleep(2000);
        }

        public void CreateViews()
        {
            _dbOperation.CreateViews();
            Thread.Sleep(2000);
        }

        public void InsertExampleData()
        {
            _dbOperation.InsertExamplesData();
            Thread.Sleep(2000);
        }

        public void InsertNonValidData()
        {
            _dbOperation.InsertNotValidData();
            Thread.Sleep(2000);
        }

        #region Procedure

        public void FindRace()
        {
            Console.Write("Race:");
            string race = Console.ReadLine();
            Console.WriteLine("");
            Console.Write("Sex (m - male/k - female):");
            string sex = Console.ReadLine();
            int result = _dbOperation.dbProcedure.FindRace(race, sex[0]);
            if (result == -1)
            {
                Console.WriteLine("Race not found");
            }
            else
            {
                Console.WriteLine("Race found id: " + result);
            }
            Thread.Sleep(2000);
        }

        public void FindClass()
        {
            Console.Write("Class name:");
            string className = Console.ReadLine();
            Console.WriteLine("");
            int result = _dbOperation.dbProcedure.FindClass(className);
            if (result == -1)
            {
                Console.WriteLine("Class not found");
            }
            else
            {
                Console.WriteLine("Class found id: " + result);
            }
            Thread.Sleep(2000);
        }

        public void CheckIsAccountExists()
        {
            int id = Utils.GetIntFromConsole("Acc ID:");
      
            //do
            //{
            //    Console.WriteLine("ID:");
            //    id_string = Console.ReadLine();
            //    tryParse = int.TryParse(id_string, out id);
            //    if (!tryParse)
            //    {
            //        Console.WriteLine("Type number");
            //    }
            //} while (!tryParse);

            bool result = _dbOperation.dbProcedure.CheckIsAccountExists(id);
            if (result)
            {
                Console.WriteLine("Account exists");
            }
            else
            {
                Console.WriteLine("Account not exists");
            }
            Thread.Sleep(2000);
        }

        public void GeneratePosition()
        {
           int result =  _dbOperation.dbProcedure.GeneratePosition();
            if (result == -1)
            {
                Console.WriteLine("Cannot generate position");
            }
            else
            {
                Console.WriteLine("Generated position ID: "+ result);
            }
            Thread.Sleep(2000);
        }

        public void GenerateLook()
        {
            Console.Write("Sex (m - male/k - female):");
            string sex = Console.ReadLine();
            int result = _dbOperation.dbProcedure.GenerateLook(sex[0]);
            if (result == -1)
            {
                Console.WriteLine("Cannot generate look");
            }
            else
            {
                Console.WriteLine("Generated look ID: " + result);
            }
            Thread.Sleep(2000);
        }

        public void AddStatistics()
        {
            int classId = Utils.GetIntFromConsole("Class id:");
            int raceId = Utils.GetIntFromConsole("Race id:");
            int result = _dbOperation.dbProcedure.AddStatistics(classId, raceId);
            if (result == -1)
            {
                Console.WriteLine("Cannot add new statistics");
            }
            else
            {
                Console.WriteLine("Generated statistics ID: " + result);
            }
            Thread.Sleep(2000);
        }

        public void AddCharacter()
        {
            int accId = Utils.GetIntFromConsole("Account ID:");
            Console.Write("Nickname:");
            string nickname = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Race:");
            string race = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Class name:");
            string className = Console.ReadLine();
            Console.WriteLine("");

            Console.Write("Sex (m - male/k - female):");
            string sex = Console.ReadLine();
            Console.WriteLine("");
            int result = _dbOperation.dbProcedure.AddCharacter(accId, nickname, race, className, sex[0]);
            if (result == -1)
            {
                Console.WriteLine("Cannot create new character");
            }
            else
            {
                Console.WriteLine("New character ID: "+ result);
            }
            Thread.Sleep(2000);
        }

        #endregion



        #endregion

        #region ORM



        #endregion
    }
}