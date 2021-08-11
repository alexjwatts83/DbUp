using System;
using DbUp.Helpers;

namespace DbUp.Infrastructure.Persistence
{
    public static class PersistenceDbMigrations
    {
        public static void EnsureDdb(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);
        }

        public static int MigrateAllTheThings(string connectionString)
        {
            OutputEmbeddedResources();

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsAndCodeEmbeddedInAssembly(
                        typeof(ConnectionStringSettings).Assembly,
                        options => options.Contains("Scripts"))
                    .WithTransactionPerScript()
                    .LogToConsole()
                    .LogScriptOutput()
                    .JournalToSqlTable("dbo", "VersionInfo")
                    .WithVariable("TableName", "Moviez")
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                return ReturnError(result.Error.ToString());
            }

            var alwaysRunUpgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsAndCodeEmbeddedInAssembly(
                        typeof(ConnectionStringSettings).Assembly,
                        options => options.Contains("Always"))
                    .JournalTo(new NullJournal())
                    .LogScriptOutput()
                    .LogToConsole()
                    .Build();

            result = alwaysRunUpgrader.PerformUpgrade();

            ShowSuccess();
            
            return 0;
        }

        private static void ShowSuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
        }

        private static int ReturnError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ResetColor();
            return -1;
        }

        private static void OutputEmbeddedResources()
        {
            foreach (var name in typeof(ConnectionStringSettings).Assembly.GetManifestResourceNames())
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{name}");
                Console.ResetColor();
            }
        }
    }
}
