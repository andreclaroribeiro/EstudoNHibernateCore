using NHibernate;

namespace EstudoNHibernateCore.Infra.Data
{
    public interface IDataBaseBuilder
    {
        ISessionFactory CreateSessionFactory();
    }
}