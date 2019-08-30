using System;
using System.Collections.Generic;

namespace Senai.AutoPeças.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPecas { get; set; }
        public int CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string PrecoCusto { get; set; }
        public string PrecoVenda { get; set; }
        public int? IdFornecedor { get; set; }

        public Fornecedores IdFornecedorNavigation { get; set; }
    }
}
