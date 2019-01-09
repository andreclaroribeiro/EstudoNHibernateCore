using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;

namespace EstudoNHibernateCore.Infra.Data
{
    public class SqlServerConfigurer : IDatabaseConfigurer
    {
        private readonly string _connectionString;
        private readonly string _mapAssemblyName;

        public SqlServerConfigurer(string connectionString, string mapAssemblyName)
        {
            _connectionString = connectionString;
            _mapAssemblyName = mapAssemblyName;
        }

        public IPersistenceConfigurer Configurer()
        {
            //return MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source = .;Initial Catalog=EstudoDB;User id=user_sys;Password=1q2w3e;");
            return MsSqlConfiguration.MsSql2012.ConnectionString(@_connectionString);
        }

        public Assembly AssemblyName()
        {
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory + _mapAssemblyName;
            return Assembly.LoadFrom(assemblyPath);
        }

        public void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Create(false, true);
        }
    }
}