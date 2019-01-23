using System;

namespace mmo_pd_db_client
{
    public class Utils
    {
        public static int GetIntFromConsole(string message)
        {
            string user_response = string.Empty;
            int num;
            bool tryParse = false;
            do
            {
                Console.WriteLine(message);
                user_response = Console.ReadLine();
                tryParse = int.TryParse(user_response, out num);
                if (!tryParse)
                {
                    Console.WriteLine("Type number");
                }
            } while (!tryParse);

            return num;
        }
    }
}