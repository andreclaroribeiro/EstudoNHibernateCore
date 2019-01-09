using System;
using NHibernate;

namespace EstudoNHibernateCore.Infra.Data
{
    public interface ISessionFactoryBuilder// : IDisposable
    {
        ISession OpenSession();
    }
}