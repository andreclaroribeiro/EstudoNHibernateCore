using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using System.Reflection;

namespace EstudoNHibernateCore.Infra.Data
{
    public interface IDatabaseConfigurer
    {
        IPersistenceConfigurer Configurer();
        Assembly AssemblyName();
        void BuildSchema(Configuration configuration);
    }
}