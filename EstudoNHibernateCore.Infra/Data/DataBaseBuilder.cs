using System;
using FluentNHibernate.Cfg;
using NHibernate;

namespace EstudoNHibernateCore.Infra.Data
{
    public class DataBaseBuilder : IDataBaseBuilder
    {
        private readonly IDatabaseConfigurer _databaseConfigurer;

        public DataBaseBuilder(IDatabaseConfigurer databaseConfigurer)
        {
            _databaseConfigurer = databaseConfigurer;
        }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(_databaseConfigurer.Configurer)
                //.Mappings(m => m.FluentMappings.AddFromAssembly(AssemblyLocator.GetByName("EstudoNHibernateCore.Infra.dll")))
                .Mappings(m => m.FluentMappings.AddFromAssembly(_databaseConfigurer.AssemblyName()))
                .ExposeConfiguration(c => c
                                          .SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, Boolean.TrueString)
                                          .SetProperty(NHibernate.Cfg.Environment.WrapResultSets, Boolean.TrueString)
                                          .SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.UseQueryCache, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.ShowSql, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, Boolean.FalseString)
                                          .SetProperty(NHibernate.Cfg.Environment.CurrentSessionContextClass, "web")
                                          .SetProperty(NHibernate.Cfg.Environment.FormatSql, Boolean.FalseString)
                                          ).BuildConfiguration().BuildSessionFactory();
        }
    }
}