using System;
using mmo_pd_db_client.Manual.DB.Constants;
using Oracle.ManagedDataAccess.Client;

namespace mmo_pd_db_client.Manual.DB
{
    public class DbOperation
    {
        private DbConnection dbConnection;

        public DbOperation()
        {
            dbConnection = new DbConnection();
        }

        public  void DropTables()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.dropTablesQuery;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Drop tables successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot drop tables!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);

                }
                finally
                {
                    dbConnection.CloseConnection();
                }
            
            }
        }

        public void CreateTables()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.createTablesQuery;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Create tables successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot create tables!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
       
            }
        }

        public void DropSequences()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.dropSequencesQuery;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Drop sequences successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot drop sequence!");
                    Console.WriteLine("Exception message: "+ ex.Message);
                    Console.WriteLine("Exception source: "+ex.Source);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
                
               
            }
        }

        public void CreateSequences()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.createSequencesQuery;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Create sequences successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot create sequence!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }
         
            }
        }


        public void InsertExamplesData()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.insertExampleDatas;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Insert data successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot insert data!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }

            }
        }

        public void InsertNotValidData()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                try
                {
                    cmd.CommandText = SqlQuery.insertNotValidData;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Insert data successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot insert data!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }
                finally
                {
                    dbConnection.CloseConnection();
                }

            }
        }
    }
}