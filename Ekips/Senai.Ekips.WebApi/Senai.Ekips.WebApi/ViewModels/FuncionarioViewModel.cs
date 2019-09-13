using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.ViewModels
{
    public class FuncionarioViewModel
    {
        public Cargos IdCargoNavigation { get; set; }
        public Departamentos IdDepartamentoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
