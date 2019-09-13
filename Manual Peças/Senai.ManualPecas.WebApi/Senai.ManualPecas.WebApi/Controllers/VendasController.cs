using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.ManualPecas.WebApi.Repositories;
using Senai.ManualPecas.WebApi.ViewModels;

namespace Senai.ManualPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        VendaRepository VendaRepository = new VendaRepository();

        [HttpPost]
        public IActionResult CadastrarVenda(VendaViewModel Venda)
        {
            try
            {
                VendaRepository.Cadastrar(Venda);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}