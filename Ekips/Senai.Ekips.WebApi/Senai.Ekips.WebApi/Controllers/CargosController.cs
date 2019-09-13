using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [Authorize]
        [HttpGet]
        public IActionResult ListarCargos()
        {
            return Ok(CargoRepository.Listar());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult BuscarCargoPorId(int id)
        {
            Cargos cargo = CargoRepository.BuscarPorId(id);

            if (cargo == null)
            {
                return null;
            }
            return Ok(cargo);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CadastrarCargo(Cargos cargo)
        {            
            try
            {
                CargoRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult AtualizarCargo(Cargos cargo)
        {
            try
            {
                Cargos CargoEncontrado = CargoRepository.BuscarPorId(cargo.IdCargo);

                if (CargoEncontrado == null)
                {
                    return NotFound();
                }
                CargoRepository.Atualizar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Eita, erro :/ ." + ex.Message });
            }
        }
    }
}