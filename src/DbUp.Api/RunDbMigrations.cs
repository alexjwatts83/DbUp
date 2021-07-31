using DbUp.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DbUp.Api
{
    internal static class RunDbMigrations
    {
        internal static void Run(IHost host)
        {
            var options = GetDbUpOptions(host);

            PersistenceDbMigrations.EnsureDdb(options.DbConnectionString);
        }

        private static DbUpOptions GetDbUpOptions(IHost host)
        {
            var options = new DbUpOptions();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                options.DbConnectionString = config.GetConnectionString("Database");
            }
            return options;
        }
    }
}
