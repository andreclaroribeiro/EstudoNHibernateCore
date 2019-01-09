namespace EstudoNHibernateCore.Entities
{
    public class ContaCorrente
    {
        public virtual int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Conta Conta { get; set; }
    }
}