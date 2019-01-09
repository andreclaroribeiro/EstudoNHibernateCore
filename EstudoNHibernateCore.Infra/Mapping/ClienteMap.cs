using EstudoNHibernateCore.Entities;
using FluentNHibernate.Mapping;

namespace EstudoNHibernateCore.Infra.Mapping
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Table("Cliente");
            LazyLoad();

            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Nome);
        }
    }
}