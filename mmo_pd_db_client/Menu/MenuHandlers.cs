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
            if (accounts.Any())
            {
                foreach (KONTA rec in accounts)
                {
                    Console.WriteLine(
                        $"ID:{rec.ID} EMAIL: {rec.EMAIL} LOGIN: {rec.LOGIN} PASSWORD HASH: {rec.PASSWORD_HASH} CREATED AT: {rec.CREATED_AT} ");
                }
                Console.WriteLine("Click any button to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Account not found");
                Thread.Sleep(1000);
            }
     
        }

        public void PrintOneAccount()
        {
            int id = Utils.GetIntFromConsole("Acc ID:");
            KONTA rec = _unitOfWork.AccountRepository.GetById(id);
            if (rec != null)
            {
                Console.WriteLine(
                    $"ID:{rec.ID} EMAIL: {rec.EMAIL} LOGIN: {rec.LOGIN} PASSWORD HASH: {rec.PASSWORD_HASH} CREATED AT: {rec.CREATED_AT} ");
                Console.WriteLine("Click any button to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Account not found");
                Thread.Sleep(1000);
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
                Console.WriteLine("Account deleted");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Accont not found");
                Thread.Sleep(1000);
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
            Thread.Sleep(1000);
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
                _unitOfWork.AccountRepository.Edit(account);
                _unitOfWork.AccountRepository.Save();
                Console.WriteLine("Account modified");
            }
            else
            {
                Console.WriteLine("Accont not found");
            }
            Thread.Sleep(2000);

        }

        public void AccountMenu()
        {
            int choice;
            string userChoice = String.Empty;
            do
            {
                Console.Clear();
                Utils.PrintOrmOperationMenu();
                Console.Write("Choice:");
                userChoice = Console.ReadLine();
                Console.WriteLine("");
                if (!int.TryParse(userChoice, out choice)) continue;
                if (choice == 0) break;
                HandleAccountMenu(choice);

            } while (true);
        }

        private void HandleAccountMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    PrintAllAccounts();
                    break;
                case 2:
                    PrintOneAccount();
                    break;
                case 3:
                    DeleteAccount();
                    break;
                case 4:
                    CreateAccount();
                    break;
                case 5:
                    ModifyAccount();
                    break;
                default:
                    Console.WriteLine("Option with this number not exists.");
                    break;

            }
        }


        #endregion

        #region BaseStatistics

        public void PrintAllBaseStat()
        {
            List<BAZOWE_STATYSTYKI> stats = _unitOfWork.BaseStatisticsRepository.GetAll().ToList();
            if (stats.Any())
            {
                foreach (BAZOWE_STATYSTYKI rec in stats)
                {
                    Console.WriteLine(
                        $"ID:{rec.ID} BASE HP: {rec.BASE_HP} BASE AG: {rec.BASE_AG} BASE INT: {rec.BASE_INT} BASE MP: {rec.BASE_MP} BASE STAMINA:{rec.BASE_STAMINA} BASE STR{rec.BASE_STR} ");
                }
                Console.WriteLine("Click any button to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Base stat not found");
                Thread.Sleep(2000);
            }
 
        }


        public void PrintOneBaseStat()
        {
            int id = Utils.GetIntFromConsole("Base stat ID:");
            BAZOWE_STATYSTYKI rec = _unitOfWork.BaseStatisticsRepository.GetById(id);
            if (rec != null)
            {
                Console.WriteLine(
                    $"ID:{rec.ID} BASE HP: {rec.BASE_HP} BASE AG: {rec.BASE_AG} BASE INT: {rec.BASE_INT} BASE MP: {rec.BASE_MP} BASE STAMINA:{rec.BASE_STAMINA} BASE STR{rec.BASE_STR} ");
                Console.WriteLine("Click any button to continue");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Base stat not found");
                Thread.Sleep(1000);
            }

        }

        public void DeleteBaseStat()
        {
            int id = Utils.GetIntFromConsole("Base stat ID to delete:");
            BAZOWE_STATYSTYKI rec = _unitOfWork.BaseStatisticsRepository.GetById(id);
            if (rec != null)
            {
                _unitOfWork.BaseStatisticsRepository.Delete(rec);
                _unitOfWork.BaseStatisticsRepository.Save();
                Console.WriteLine("Base stat deleted");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Base stat not found");
                Thread.Sleep(1000);
            }
        }

        public void CreateBaseStat()
        {
            BAZOWE_STATYSTYKI bs = new BAZOWE_STATYSTYKI();
            bs.BASE_AG = Utils.GetIntFromConsole("BASE AG");
            bs.BASE_HP = Utils.GetIntFromConsole("BASE HP");
            bs.BASE_INT = Utils.GetIntFromConsole("BASE INT");
            bs.BASE_MP = Utils.GetIntFromConsole("BASE MP");
            bs.BASE_STAMINA = Utils.GetIntFromConsole("BASE STAMINA");
            bs.BASE_STR = Utils.GetIntFromConsole("BASE STR");
            _unitOfWork.BaseStatisticsRepository.Add(bs);
            _unitOfWork.BaseStatisticsRepository.Save();
            Console.WriteLine("Base stat created");
            Thread.Sleep(1000);
        }

        public void ModifyBaseStat()
        {
            int id = Utils.GetIntFromConsole("Base stat ID to modify:");
            BAZOWE_STATYSTYKI bs = _unitOfWork.BaseStatisticsRepository.GetById(id);
            if (bs != null)
            {
                bs.BASE_AG = Utils.GetIntFromConsole("BASE AG");
                bs.BASE_HP = Utils.GetIntFromConsole("BASE HP");
                bs.BASE_INT = Utils.GetIntFromConsole("BASE INT");
                bs.BASE_MP = Utils.GetIntFromConsole("BASE MP");
                bs.BASE_STAMINA = Utils.GetIntFromConsole("BASE STAMINA");
                bs.BASE_STR = Utils.GetIntFromConsole("BASE STR");
                _unitOfWork.BaseStatisticsRepository.Edit(bs);
                _unitOfWork.BaseStatisticsRepository.Save();
                Console.WriteLine("Base stat modified");
            }
            else
            {
                Console.WriteLine("Base stat not found");
            }
            Thread.Sleep(2000);

        }

        public void BaseStatMenu()
        {
            int choice;
            string userChoice = String.Empty;
            do
            {
                Console.Clear();
                Utils.PrintOrmOperationMenu();
                Console.Write("Choice:");
                userChoice = Console.ReadLine();
                Console.WriteLine("");
                if (!int.TryParse(userChoice, out choice)) continue;
                if (choice == 0) break;
                HandleBaseStatMenu(choice);

            } while (true);
        }

        private void HandleBaseStatMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    PrintAllBaseStat();
                    break;
                case 2:
                    PrintOneBaseStat();
                    break;
                case 3:
                    DeleteBaseStat();
                    break;
                case 4:
                    CreateBaseStat();
                    break;
                case 5:
                    ModifyBaseStat();
                    break;
                default:
                    Console.WriteLine("Option with this number not exists.");
                    break;

            }
        }

        #endregion

        #endregion
    }
}