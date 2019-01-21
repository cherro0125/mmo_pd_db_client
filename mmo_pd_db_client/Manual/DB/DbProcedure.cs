namespace mmo_pd_db_client.Manual.DB
{
    public class DbProcedure
    {
        private DbConnection dbConnection;

        public DbProcedure(DbConnection conn)
        {
            dbConnection = conn;
        }
    }
}