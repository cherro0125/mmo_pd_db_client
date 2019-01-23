using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

        #region Account

        public void PrintAllAccounts()
        {
            List<KONTA> accounts = _unitOfWork.AccountRepository.GetAll().ToList();
            foreach (KONTA rec in accounts)
            {
                Console.WriteLine(String.Format("ID:{0} EMAIL: {1} LOGIN: {2} PASSWORD HASH: {3} CREATED AT: {4} ",rec.ID,rec.EMAIL,rec.PASSWORD_HASH,rec.CREATED_AT));
            }
            Console.WriteLine("Click any button to continue");
            Console.ReadKey();
        }

        public void PrintOneAccount()
        {
            int id = Utils.GetIntFromConsole("Acc ID:");
            KONTA rec = _unitOfWork.AccountRepository.GetById(id);
            if (rec != null)
            {
                Console.WriteLine(String.Format("ID:{0} EMAIL: {1} LOGIN: {2} PASSWORD HASH: {3} CREATED AT: {4} ", rec.ID, rec.EMAIL, rec.PASSWORD_HASH, rec.CREATED_AT));
            }
            else
            {
                Console.WriteLine("Account not found");
            }

        }

        public void DeleteAccount()
        {
            int id = Utils.GetIntFromConsole("Acc ID to delete:");
            KONTA rec = _unitOfWork.AccountRepository.GetById(id);
            if (rec != null)
            {
                _unitOfWork.AccountRepository.Delete(rec);
                _unitOfWork.AccountRepository.Save();                
            }
            else
            {
                Console.WriteLine("Accont not found");
            }
        }

        public void CreateAccount()
        {
            KONTA account = new KONTA();
            account.EMAIL = Utils.GetStringFromConsole("EMAIL:");
            account.LOGIN = Utils.GetStringFromConsole("LOGIN:");
            string password = Utils.GetStringFromConsole("PASSWORD:");
            account.PASSWORD_HASH = Utils.CreateMD5(password);
            account.CREATED_AT = DateTime.Now;
            _unitOfWork.AccountRepository.Add(account);
            _unitOfWork.AccountRepository.Save();
            Console.WriteLine("Account created");            
        }

        public void ModifyAccount()
        {
            int id = Utils.GetIntFromConsole("Acc ID to modify:");
            KONTA account = _unitOfWork.AccountRepository.GetById(id);
            if (account != null)
            {
                account.EMAIL = Utils.GetStringFromConsole("EMAIL:");
                account.LOGIN = Utils.GetStringFromConsole("LOGIN:");
                string password = Utils.GetStringFromConsole("PASSWORD:");
                account.PASSWORD_HASH = Utils.CreateMD5(password);
                account.CREATED_AT = DateTime.Now;
                _unitOfWork.AccountRepository.Add(account);
                _unitOfWork.AccountRepository.Save();
                Console.WriteLine("Account modified");
            }
            else
            {
                Console.WriteLine("Accont not found");
            }
         
        }


        #endregion

        #endregion
    }
}