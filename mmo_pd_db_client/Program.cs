using System;
using System.Collections.Generic;
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
            op.CloseConnection();
            int test2 = op.dbProcedure.FindClass("traitor");
            Console.WriteLine("Test2 klasa:" + test2);
            bool test3 = op.dbProcedure.CheckIsAccountExists(55);
            Console.WriteLine("Test3:" + test3);
            Console.ReadKey();


        }
    }
}
