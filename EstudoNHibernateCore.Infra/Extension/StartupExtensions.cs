using EstudoNHibernateCore.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EstudoNHibernateCore.Infra.Extension
{
    public static class StartupExtensions
    {
        public static void ConfigureSessionDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString(AppProperties.ConnectionStringPrincipalKey);
            string mapAssemblyName = configuration[AppProperties.MapAssemblyKey];

            services.AddScoped<IDatabaseConfigurer, SqlServerConfigurer>(x => new SqlServerConfigurer(connectionString, mapAssemblyName));
            services.AddScoped<IDataBaseBuilder, DataBaseBuilder>();
            services.AddScoped(x => x.GetRequiredService<IDataBaseBuilder>().CreateSessionFactory());
            services.AddScoped(x => x.GetRequiredService<NHibernate.ISessionFactory>().OpenSession());
        }
    }
}