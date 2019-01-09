using System.Linq;
using System.Collections.Generic;
using EstudoNHibernateCore.Infra.Data;

namespace EstudoNHibernateCore.Infra.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> //where T : Entity.EntityBase
    {
        protected NHibernate.ISession Session;

        public RepositoryBase(NHibernate.ISession session)
        {
            Session = session;
        }

        //public virtual NHibernate.ISession OpenSession()
        //{
        //    return SessionFactoryBuilder.OpenSession();
        //}

        //protected NHibernate.ISession Session;

        //public RepositoryBase(NHibernate.ISession session)
        //{
        //    Session = session;
        //}

        public void Delete(T entity)
        {
            //using (var session = OpenSession())
            //{
            //    session.Delete(entity);
            //}                
        }

        public void Delete(ICollection<T> entities)
        {
            //foreach (var entity in entities)
            //{
            //    Delete(entity);
            //}
        }

        public void SaveOrUpdate(T entity)
        {
            //using (var session = OpenSession())
            //{
            //    session.SaveOrUpdate(entity);
            //}
        }

        public void SaveOrUpdate(ICollection<T> entities)
        {
            //foreach (var entity in entities)
            //{
            //    SaveOrUpdate(entity);
            //}
        }

        public ICollection<T> FindAll()
        {
            //using (var session = OpenSession())
            //{
                return Session.Query<T>().ToList();
            //}
            //return this.Session.Query<T>().ToList();
        }

    }
}