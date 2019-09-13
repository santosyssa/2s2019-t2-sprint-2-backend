using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        ManualPecasContext ctx = new ManualPecasContext();

        public void Cadastrar(Fornecedores fornecedor)
        {
            ctx.Fornecedores.Add(fornecedor);
            ctx.SaveChanges();
        }

        public List<Fornecedores> Listar()
        {
            return ctx.Fornecedores.ToList();
            //abir cone

        }
    }
}
