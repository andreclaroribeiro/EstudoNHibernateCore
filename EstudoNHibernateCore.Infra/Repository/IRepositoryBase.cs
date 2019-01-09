using System.Collections.Generic;

namespace EstudoNHibernateCore.Infra.Repository
{
    public interface IRepositoryBase<T> //where T : Entity.EntityBase
    {
        void SaveOrUpdate(T entity);

        void SaveOrUpdate(ICollection<T> entity);

        void Delete(T entity);

        void Delete(ICollection<T> entity);

        ICollection<T> FindAll();

        //T GetById(int id);

        //ICollection<T> FindByIds(IList<int> ids);
    }
}