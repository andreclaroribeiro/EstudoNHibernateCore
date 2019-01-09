using System;
using System.Collections.Generic;
using EstudoNHibernateCore.Entities;
using EstudoNHibernateCore.Infra.Data;
using EstudoNHibernateCore.Infra.Repository;

namespace EstudoNHibernateCore.Repositories
{
    public class ContaCorrenteRepository : RepositoryBase<ContaCorrente>, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(NHibernate.ISession session) : base(session)
        {
        }

        public void Insert(ContaCorrente contaCorrente)
        {
            using (var transaction = Session.Transaction)
            {
                Session.SaveOrUpdate(contaCorrente);
                Session.Flush();
            }
        }

        public void Delete(int id)
        {

        }

        //public ContaCorrenteRepository(NHibernate.ISession session) : base(session)
        //{

        //}
        //public void Delete(ContaCorrente entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(ICollection<ContaCorrente> entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveOrUpdate(ContaCorrente entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SaveOrUpdate(ICollection<ContaCorrente> entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
