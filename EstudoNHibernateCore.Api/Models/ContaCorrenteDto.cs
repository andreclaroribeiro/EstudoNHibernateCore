namespace EstudoNHibernateCore.Api.Models
{
    public class ContaCorrenteDto
    {
        public int Id { get; set; }
        public ClienteDto Cliente { get; set; }
        public int Numero { get; set; }
        public string Digito { get; set; }
    }
}