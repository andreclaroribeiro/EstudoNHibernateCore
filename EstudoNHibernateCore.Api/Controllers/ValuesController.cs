using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstudoNHibernateCore.Api.Models;
using EstudoNHibernateCore.Entities;
using EstudoNHibernateCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EstudoNHibernateCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IContaCorrenteRepository _contaCorrenteRepsitory;

        public ValuesController(IContaCorrenteRepository contaCorrenteRepsitory)
        {
            _contaCorrenteRepsitory = contaCorrenteRepsitory;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ContaCorrenteDto>> Get()
        {
            var contas = _contaCorrenteRepsitory.FindAll();

            var contas2 = _contaCorrenteRepsitory.FindAll();

            var contas3 = _contaCorrenteRepsitory.FindAll();
            
            return ModelTo(contas).ToList();

            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ContaCorrenteDto contaCorrente)
        {
            var conta = new ContaCorrente
            {
                Id = contaCorrente.Id,
                Cliente = new Cliente { Id = contaCorrente.Cliente.Id, Nome = contaCorrente.Cliente.Nome },
                Conta = new Conta { Numero = contaCorrente.Numero, Digito = contaCorrente.Digito }
            };

            _contaCorrenteRepsitory.Insert(conta);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private IEnumerable<ContaCorrenteDto> ModelTo(IEnumerable<ContaCorrente> contas)
        {
            var result = new List<ContaCorrenteDto>();

            foreach (var item in contas)
            {
                result.Add(
                    new ContaCorrenteDto
                    {
                        Id = item.Id,
                        Cliente = new ClienteDto
                        {
                            Id = item.Cliente.Id,
                            Nome = item.Cliente.Nome
                        },
                        Numero = item.Conta.Numero,
                        Digito = item.Conta.Digito
                    });
            }
            
            return result;
        }
    }
}
