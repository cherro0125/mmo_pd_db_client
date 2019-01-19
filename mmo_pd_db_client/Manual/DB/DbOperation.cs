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
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = dbConnection.connection;
                cmd.CommandText = SqlQuery.dropTablesQuery;
                cmd.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }

        public void CreateTables()
        {
            dbConnection.OpenConnection();
            using (dbConnection.connection)
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = dbConnection.connection;
                cmd.CommandText = SqlQuery.createTablesQuery;
                cmd.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }
    }
}