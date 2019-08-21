using Microsoft.AspNetCore.Mvc;
using Senai.People.WebApi.Domains;
using Senai.People.WebApi.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.People.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        [HttpGet]
        public IEnumerable<FuncionarioDomain> ListarTodos()
        {
            return FuncionarioRepository.Listar();
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionarioDomain = FuncionarioRepository.BuscarPorId(id);

            if (funcionarioDomain == null)
            {
                return NotFound();

            }

            return Ok(funcionarioDomain);
        }

        [HttpPost]
        public IActionResult Cadastrar (FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Cadastrar(funcionarioDomain);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(FuncionarioDomain funcionarioDomain)
        {
            FuncionarioRepository.Atualizar(funcionarioDomain);
            return Ok();
        }


    }
}
