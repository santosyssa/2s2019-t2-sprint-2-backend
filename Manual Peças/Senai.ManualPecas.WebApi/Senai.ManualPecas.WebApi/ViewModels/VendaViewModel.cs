using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.ViewModels
{
    public class VendaViewModel
    {
        public int IdPeca { get; set; }
        public int IdFornecedor { get; set; }
        public float Preco { get; set; }
    }
}
