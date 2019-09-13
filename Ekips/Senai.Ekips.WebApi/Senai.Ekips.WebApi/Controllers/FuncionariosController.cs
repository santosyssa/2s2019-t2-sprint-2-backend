using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository FuncionarioRepository = new FuncionarioRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int id = Convert.ToInt32(identity.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
            string role = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
            
            if (role == "Administrador")
            {
                return Ok(FuncionarioRepository.Listar());
            }
            return Ok(FuncionarioRepository.BuscarPorId(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarFuncionario(Funcionarios funcionario)
        {
            try
            {
                FuncionarioRepository.Cadastrar(funcionario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });

            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult AtualizarFuncionario(Funcionarios funcionario)
        {
            try
            {
                Funcionarios FuncionarioEncontrado = FuncionarioRepository.BuscarPorId(funcionario.IdFuncionario);

                if (FuncionarioEncontrado == null)
                {
                    return NotFound();
                }
                FuncionarioRepository.Atualizar(funcionario);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletarFuncionario(int id)
        {
            FuncionarioRepository.Deletar(id);
            return Ok();
        }
    }
}