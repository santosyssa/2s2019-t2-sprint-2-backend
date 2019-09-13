using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        ManualPecasContext ctx = new ManualPecasContext();

        public void Atualizar(Pecas peca)
        {
            Pecas PecaProcurada = ctx.Pecas.FirstOrDefault(x => x.IdPeca == peca.IdPeca);
            PecaProcurada.CodigoPeca = peca.CodigoPeca;
            PecaProcurada.Descricao = peca.Descricao;
            ctx.Pecas.Update(PecaProcurada);
            ctx.SaveChanges();
        }

        public Pecas BuscarPorId(int id)
        {
            Pecas peca = ctx.Pecas.FirstOrDefault(x => x.IdPeca == id);
            return peca;
        }

        public void Cadastrar(Pecas peca)
        {
            ctx.Pecas.Add(peca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pecas peca = ctx.Pecas.Find(id);
            ctx.Pecas.Remove(peca);
            ctx.SaveChanges();
        }

        public List<Pecas> Listar()
        {
            return ctx.Pecas.ToList();
        }
    }
}
