using EstudoNHibernateCore.Entities;
using FluentNHibernate.Mapping;

namespace EstudoNHibernateCore.Infra.Mapping
{
    public class ContaCorrenteMap : ClassMap<ContaCorrente>
    {
        public ContaCorrenteMap()
        {
            Table("ContaCorrente");
            LazyLoad();

            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.Cliente, "IdCliente");
            Component(x => x.Conta, c =>
            {
                c.Map(x => x.Numero, "Numero");
                c.Map(x => x.Digito, "Digito");
            });
        }
    }
}