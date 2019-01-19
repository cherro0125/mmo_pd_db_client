using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace mmo_pd_db_client.Manual.DB
{
    public class DbConnection
    {
        public string connectionString { get; set; }
        public OracleConnection connection { get; set; }

        public DbConnection()
        {
            connectionString = "Data Source=127.0.0.1/xe;User Id=mmo_pd;Password=mmo_pd;";
            connection = new OracleConnection(connectionString);
        }

        public void OpenConnection()
        {
            if(connection.State != ConnectionState.Open)
                connection.Open();
        }

        public void CloseConnection()
        {
            if(connection.State != ConnectionState.Closed)
                connection.Close();
        }

    }
}