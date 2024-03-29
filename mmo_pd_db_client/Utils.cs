﻿using System;
using System.Text;

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

        public static float GetFloatFromConsole(string message)
        {
            string user_response = string.Empty;
            float num;
            bool tryParse = false;
            do
            {
                Console.WriteLine(message);
                user_response = Console.ReadLine();
                tryParse = float.TryParse(user_response, out num);
                if (!tryParse)
                {
                    Console.WriteLine("Type number");
                }
            } while (!tryParse);

            return num;
        }

        public static decimal GetDecimalFromConsole(string message)
        {
            string user_response = string.Empty;
            decimal num;
            bool tryParse = false;
            do
            {
                Console.WriteLine(message);
                user_response = Console.ReadLine();
                tryParse = decimal.TryParse(user_response, out num);
                if (!tryParse)
                {
                    Console.WriteLine("Type number");
                }
            } while (!tryParse);

            return num;
        }

        public static string GetStringFromConsole(string message)
        {
            Console.Write(message);
            string user_response = Console.ReadLine();
            Console.WriteLine("");
            return user_response;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static void PrintOrmOperationMenu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("To use this procedure you must create tables,sequences, triggers and packages");
            Console.WriteLine("1. Print all");
            Console.WriteLine("2. Print one");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Add new");
            Console.WriteLine("5. Modify");

            Console.WriteLine("0. Return to ORM menu");
            Console.WriteLine("---------------------------");
        }
    }


}