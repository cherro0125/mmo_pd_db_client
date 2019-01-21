using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mmo_pd_db_client.Manual.DB;

namespace mmo_pd_db_client
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var context = new Entities1())
            //{
            //    KLASY_POSTACI kp = context.KLASY_POSTACI.Find(1);

            //    Console.WriteLine(kp.BAZOWE_STATYSTYKI.BASE_AG);
            //    Console.ReadKey();
            //}

            DbOperation op = new DbOperation();

            op.DropTables();
            op.DropSequences();
            op.CreateSequences();
            op.CreateTables();
            Console.WriteLine("----------------");
            op.DropTriggers();
            op.CreateTriggers();
            op.InsertExamplesData();
            op.DropPackages();
            op.CreatePackages();
            int test = op.dbProcedure.FindRace("human", 'm');
            Console.WriteLine("Test: " + test);    
            int test2 = op.dbProcedure.FindClass("traitor");
            Console.WriteLine("Test2 klasa:" + test2);
            bool test3 = op.dbProcedure.CheckIsAccountExists(55);
            Console.WriteLine("Test3:" + test3);
            int test4 = op.dbProcedure.GeneratePosition();
            Console.WriteLine("Test4: "+ test4);
            int test5 = op.dbProcedure.GenerateLook('m');
            Console.WriteLine("Test5: " + test5);
            int test6 = op.dbProcedure.AddStatistics(1,1);
            Console.WriteLine("Test6: " + test6);
            int test7 = op.dbProcedure.AddCharacter(1, "testCSharp", "human", "warrior", 'm');
            Console.WriteLine("Test7: " + test7);
            Console.ReadKey();
            op.CloseConnection();


        }
    }
}
