using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Context;

namespace EstudoNHibernateCore.Infra.Data
{
    public class SessionFactoryBuilder : ISessionFactoryBuilder
    {
        private readonly string _connectionString;
        private readonly object _lockObject = new object();
        private ISessionFactory _sessionFactory;
        private readonly string _mapAssemblyName;

        public SessionFactoryBuilder(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
            _mapAssemblyName = configuration["MapAssemblyName"];

        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    //CreateSessionFactory();
                   // _sessionFactory = DataBaseBuilder.CreateConfiguration(_connectionString, _mapAssemblyName).BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            var _session = GetCurrentSession();

            if (_session == null)
                _session = SessionFactory.OpenSession();

            return _session;
        }

        public void CreateSession()
        {
            CurrentSessionContext.Bind(OpenSession());
        }

        public void CloseSession()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                CurrentSessionContext.Unbind(SessionFactory).Dispose();
            }
        }

        public ISession GetCurrentSession()
        {
            if (!CurrentSessionContext.HasBind(SessionFactory))
            {
                CurrentSessionContext.Bind(SessionFactory.OpenSession());
            }
            return SessionFactory.GetCurrentSession();
        }

        //private void CreateSessionFactory()
        //{
        //    lock (_lockObject)
        //    {
        //        _sessionFactory = DbConfiguration.CreateConfiguration(_connectionString, _mapAssemblyName).BuildSessionFactory();
        //    }
        //}
    }
}