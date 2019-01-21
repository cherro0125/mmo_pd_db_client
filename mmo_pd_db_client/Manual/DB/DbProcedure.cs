using System;
using System.Data;
using mmo_pd_db_client.Manual.DB.Constants;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace mmo_pd_db_client.Manual.DB
{
    public class DbProcedure
    {
        private DbConnection dbConnection;

        public DbProcedure(DbConnection conn)
        {
            dbConnection = conn;
        }

        public int FindRace(string race, char sex)
        {
            dbConnection.OpenConnection();
            OracleCommand cmd = dbConnection.connection.CreateCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ProcedureName.BuildProcedureName(PackageType.NORMAL,ProcedureName.find_race);
                cmd.BindByName = true;
                cmd.Parameters.Add("Return_Value", OracleDbType.Int16,ParameterDirection.ReturnValue);
                cmd.Parameters.Add("rasa", race);
                cmd.Parameters.Add("plec", sex);
                cmd.ExecuteNonQuery();
                return Convert.ToInt16(cmd.Parameters["Return_value"].Value.ToString());


            }
            catch (OracleException ex)
            {
                Console.WriteLine("Cannot run procedure!");
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Exception source: " + ex.Source);
                return -1;
            }
        }


        public int FindClass(string className)
        {
            dbConnection.OpenConnection();
            OracleCommand cmd = dbConnection.connection.CreateCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ProcedureName.BuildProcedureName(PackageType.NORMAL, ProcedureName.find_class);
                cmd.BindByName = true;
                cmd.Parameters.Add("Return_Value", OracleDbType.Int16, ParameterDirection.ReturnValue);
                cmd.Parameters.Add("klasa", className);               
                cmd.ExecuteNonQuery();
                return Convert.ToInt16(cmd.Parameters["Return_value"].Value.ToString());


            }
            catch (OracleException ex)
            {
                Console.WriteLine("Cannot run procedure!");
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Exception source: " + ex.Source);
                return -1;
            }
        }

        public bool CheckIsAccountExists(int id)
        {
            dbConnection.OpenConnection();
            OracleCommand cmd = dbConnection.connection.CreateCommand();
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = ProcedureName.BuildProcedureName(PackageType.NORMAL, ProcedureName.check_is_account_exists);
                cmd.BindByName = true;
                cmd.Parameters.Add("Return_Value",OracleDbType.Int16,ParameterDirection.ReturnValue);
                cmd.Parameters.Add("acc_id", id);
                cmd.ExecuteNonQuery();
                return Convert.ToBoolean(Convert.ToInt16(cmd.Parameters["Return_value"].Value.ToString()));
           




            }
            catch (OracleException ex)
            {
                Console.WriteLine("Cannot run procedure!");
                Console.WriteLine("Exception message: " + ex.Message);
                Console.WriteLine("Exception source: " + ex.Source);
                return false;
            }
        }
    }
}