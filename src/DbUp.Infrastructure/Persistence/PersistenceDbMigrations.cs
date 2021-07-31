namespace DbUp.Infrastructure.Persistence
{
    public static class PersistenceDbMigrations
    {
        public static void EnsureDdb(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);
        }
    }
}
