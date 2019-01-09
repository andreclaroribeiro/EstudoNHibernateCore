using EstudoNHibernateCore.Entities;
using EstudoNHibernateCore.Infra.Repository;

namespace EstudoNHibernateCore.Repositories
{
    public interface IContaCorrenteRepository : IRepositoryBase<ContaCorrente>
    {
        void Insert(ContaCorrente contaCorrente);
    }
}