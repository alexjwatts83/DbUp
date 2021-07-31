using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DbUp.Api
{
    internal static class RunDbMigrations
    {
        internal static void Run(IHost host)
        {
            var options = GetFluentMigratorOptions(host);
        }

        private static DbUpOptions GetFluentMigratorOptions(IHost host)
        {
            var options = new DbUpOptions();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();
                options.DbConnectionString = config.GetConnectionString("Database");
                options.MasterDb = config.GetConnectionString("Master");
                //options.MainDbName = config.GetSection(FluentMigratorSettings.MainDbName).Value;
                //options.TagsRaw = config.GetSection(FluentMigratorSettings.Tags).Value;
            }
            return options;
        }
    }
}
