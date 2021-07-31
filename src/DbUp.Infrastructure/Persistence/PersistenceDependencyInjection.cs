using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbUp.Infrastructure.Persistence
{
    public static class PersistenceDependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringSettings>(configuration.GetSection(ConnectionStringSettings.Section));

            return services;
        }
    }
}
