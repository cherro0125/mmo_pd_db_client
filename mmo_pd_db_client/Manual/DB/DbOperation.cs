using System;
using mmo_pd_db_client.Manual.DB.Constants;
using Oracle.ManagedDataAccess.Client;

namespace mmo_pd_db_client.Manual.DB
{
    public class DbOperation
    {
        private DbConnection dbConnection;
        public DbProcedure dbProcedure;

        public DbOperation()
        {
            dbConnection = new DbConnection();
            dbProcedure = new DbProcedure(dbConnection);
        }

    

        public  void DropTables()
        {
            dbConnection.OpenConnection();
         
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
            
            
            
        }

        public void CreateTables()
        {
            dbConnection.OpenConnection();
        
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
     
       
            
        }

        public void DropSequences()
        {
            dbConnection.OpenConnection();
         
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
              
                
               
            
        }

        public void CreateSequences()
        {
            dbConnection.OpenConnection();
         
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
       
         
            
        }


        public void InsertExamplesData()
        {
            dbConnection.OpenConnection();
       
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                foreach (string insertSql in SqlQuery.insertExampleData)
                {
                    try
                    {
                        Console.WriteLine("DEBUG SQL: " + insertSql);
                        cmd.CommandText = insertSql;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Insert data successful!");

                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Cannot insert data!");
                        Console.WriteLine("Exception message: " + ex.Message);
                        Console.WriteLine("Exception source: " + ex.Source);
                    }
                }
            
        }

        public void InsertNotValidData()
        {
            dbConnection.OpenConnection();

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
       
            
        }


        public void TruncateAllTables()
        {
            dbConnection.OpenConnection();
          
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                foreach (string truncateSql in SqlQuery.truncateTables)
                {
                    try
                    {
                        cmd.CommandText = truncateSql;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Truncate table successful!");
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Cannot truncate tables!");
                        Console.WriteLine("Exception message: " + ex.Message);
                        Console.WriteLine("Exception source: " + ex.Source);
                    }
                    
                }
            
        }


        public void CreateViews()
        {
            dbConnection.OpenConnection();
       
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                foreach (string createViewSql in SqlQuery.createViews)
                {
                    try
                    {
                        cmd.CommandText = createViewSql;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Create view successful!");
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Cannot create view!");
                        Console.WriteLine("Exception message: " + ex.Message);
                        Console.WriteLine("Exception source: " + ex.Source);
                    }

                }
            
        }




        public void DropTriggers()
        {
            dbConnection.OpenConnection();
       
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                foreach (string query in SqlQuery.dropTriggers)
                {
                    try
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Drop trriger successful!");
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Cannot drop trigger!");
                        Console.WriteLine("Exception message: " + ex.Message);
                        Console.WriteLine("Exception source: " + ex.Source);
                    }

                }
            
        }

        public void CreateTriggers()
        {
            dbConnection.OpenConnection();
         
                OracleCommand cmd = dbConnection.connection.CreateCommand();
                foreach (string query in SqlQuery.createTriggers)
                {
                    try
                    {
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Create trriger successful!");
                    }
                    catch (OracleException ex)
                    {
                        Console.WriteLine("Cannot create trigger!");
                        Console.WriteLine("Exception message: " + ex.Message);
                        Console.WriteLine("Exception source: " + ex.Source);
                    }

                }
            
        }

        public void DropPackages()
        {
            dbConnection.OpenConnection();

            OracleCommand cmd = dbConnection.connection.CreateCommand();
            foreach (string query in SqlQuery.dropPackages)
            {
                try
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Drop package successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot drop package!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }

            }

        }

        public void CreatePackagesHeaders()
        {
            dbConnection.OpenConnection();

            OracleCommand cmd = dbConnection.connection.CreateCommand();
            foreach (string query in SqlQuery.createPackagesHeaders)
            {
                try
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Create package header successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot create package header!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }

            }

        }

        public void CreatePackagesBodies()
        {
            dbConnection.OpenConnection();

            OracleCommand cmd = dbConnection.connection.CreateCommand();
            foreach (string query in SqlQuery.createPackagesBody)
            {
                try
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Create package body successful!");
                }
                catch (OracleException ex)
                {
                    Console.WriteLine("Cannot create package body!");
                    Console.WriteLine("Exception message: " + ex.Message);
                    Console.WriteLine("Exception source: " + ex.Source);
                }

            }

        }

        public void CreatePackages()
        {
            CreatePackagesHeaders();
            CreatePackagesBodies();
        }







        public void CloseConnection()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Closing connection to database..");
            dbConnection.CloseConnection();
            Console.WriteLine("Connection to database closed successful");
            Console.WriteLine("--------------------------------");
        }
    }
}