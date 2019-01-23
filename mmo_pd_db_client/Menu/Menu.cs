using System;

namespace mmo_pd_db_client.Menu
{
    public class Menu
    {
        private MenuHandlers _menuHandlers;

        public Menu()
        {
            _menuHandlers = new MenuHandlers();
        }

        private void PrintMenuText()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("1.Create tables");
            Console.WriteLine("2.Drop tables");
            Console.WriteLine("3. Create sequences");
            Console.WriteLine("4. Drop sequences");
            Console.WriteLine("5. Create packages");
            Console.WriteLine("6. Drop packages");
            Console.WriteLine("7.Create triggers");
            Console.WriteLine("8. Drop triggers");
            Console.WriteLine("9. Create views");
            Console.WriteLine("10. Run procedure");
            Console.WriteLine("11. ORM");
            Console.WriteLine("12. Insert example data");
            Console.WriteLine("13. Insert not valid data");
            Console.WriteLine("0. Exit");
            Console.WriteLine("---------------------------");

        }

 

        private void HandleMenu(int choice)
        {
     
            switch (choice)
            {
                case 1:
                    _menuHandlers.CreateTables();
                    break;
                case 2:
                    _menuHandlers.DropTables();
                    break;
                case 3:
                    _menuHandlers.CreateSequences();
                    break;
                case 4:
                    _menuHandlers.DropSequences();
                    break;
                case 5:
                    _menuHandlers.CreatePackages();
                    break;
                case 6:
                    _menuHandlers.DropPackages();
                    break;
                case 7:
                    _menuHandlers.CreateTriggers();
                    break;
                case 8:
                    _menuHandlers.DropTriggers();
                    break;
                case 9:
                    _menuHandlers.CreateViews();
                    break;
                case 10: 
                   RunProcedureMenu();
                    break;
                case 11:
                    //TODO : ORM handler menu
                    break;
                case 12:
                    _menuHandlers.InsertExampleData();
                    break;
                case 13:
                    _menuHandlers.InsertNonValidData();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Option with this number not exists.");
                    break;
            }
        }

        private void PrintProcedureMenuText()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("To use this procedure you must create tables,sequences, triggers and packages");
            Console.WriteLine("1. Find race");
            Console.WriteLine("2. Find class");
            Console.WriteLine("3. Check is account exists");
            Console.WriteLine("4. Generate position");
            Console.WriteLine("5. Generate look");
            Console.WriteLine("6. Add statistics");
            Console.WriteLine("7. Add character");
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("---------------------------");

        }

        private void HandleProcedureMenu(int choice)
        {
            switch (choice)
            {
                case 1:
                    _menuHandlers.FindRace();
                    break;
                case 2:
                    _menuHandlers.FindClass();
                    break;
                case 3:
                    _menuHandlers.CheckIsAccountExists();
                    break;
                case 4:
                    _menuHandlers.GeneratePosition();
                    break;
                case 5:
                   //TODO : Generate look
                    break;
                case 6:
                    //TODO : Add statistics 
                    break;
                case 7:
                    //TODO : Add character
                    break;
                default:
                    Console.WriteLine("Option with this number not exists.");
                    break;

            }
        }

        public void RunMenu()
        {
            int choice;
            string userChoice = String.Empty;
            do
            {
                Console.Clear();
                PrintMenuText();
                Console.Write("Choice:");
                userChoice = Console.ReadLine();
                Console.WriteLine("");
                if(!int.TryParse(userChoice, out choice)) continue;
                HandleMenu(choice);

            } while (true);

        }

        private void RunProcedureMenu()
        {
            int choice;
            string userChoice = String.Empty;
            do
            {
                Console.Clear();
                PrintProcedureMenuText();
                Console.Write("Choice:");
                userChoice = Console.ReadLine();
                Console.WriteLine("");
                if (!int.TryParse(userChoice, out choice)) continue;
                if (choice == 0) break;
                HandleProcedureMenu(choice);

            } while (true);
        }
    }
}