using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        EstudioRepository EstudioRepository = new EstudioRepository();

        [Authorize(Roles = "Administrador,Comum")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(EstudioRepository.Listar());
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            Estudios estudio = EstudioRepository.BuscarPorId(id);

            if (estudio == null)
            {
                return null;
            }
            return Ok(estudio);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Cadastrar (Estudios estudios)
        {
            try
            {
                EstudioRepository.Cadastrar(estudios);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/" + ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar (Estudios estudio)

        {
            try
            {
                Estudios EstudioEncontrado = EstudioRepository.BuscarPorId(estudio.IdEstudio);


                if (EstudioEncontrado == null)
                {
                    return NotFound();
                }
                EstudioRepository.Atualizar(estudio);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/" + ex.Message });
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            EstudioRepository.Deletar(id);
            return Ok();
        }
    }
}