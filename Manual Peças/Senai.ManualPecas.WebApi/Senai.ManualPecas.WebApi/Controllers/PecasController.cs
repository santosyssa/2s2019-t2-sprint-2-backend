using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using Senai.ManualPecas.WebApi.Repositories;

namespace Senai.ManualPecas.WebApi.Contexts
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecaRepository PecaRepository { get; set; }

        public PecasController()
        {
            PecaRepository = new PecaRepository();
        }

        [HttpGet]
        public IActionResult ListarPecas()
        {
            return Ok(PecaRepository.Listar());
        }

        [HttpPost]
        public IActionResult CadastrarPeca(Pecas peca)
        {
            try
            {
                PecaRepository.Cadastrar(peca);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult AtualizarPeca(Pecas peca)
        {
            try
            {
                Pecas PecaEncontrada = PecaRepository.BuscarPorId(peca.IdPeca);

                if (PecaEncontrada == null)
                {
                    return NotFound();
                }
                PecaRepository.Atualizar(peca);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPeca(int id)
        {
            PecaRepository.Deletar(id);
            return Ok();
        }
    }
}