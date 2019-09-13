using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class JogoRepository
    {
        public List<Jogos> Listar()
        {
            using (InlockContext context = new InlockContext())
            {
                return context.Jogos.ToList();
            }
        }

        public Jogos BuscarPorId (int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Jogos jogo = ctx.Jogos.FirstOrDefault(x => x.IdJogo == id);
                return jogo;
            }
        }

        public void Cadastrar (Jogos jogo)
        {
            using (InlockContext ctx = new InlockContext())
            {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar (Jogos jogo)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Jogos JogoProcurado = ctx.Jogos.FirstOrDefault(x => x.IdJogo == jogo.IdJogo);
                JogoProcurado.NomeJogo = jogo.NomeJogo;
                ctx.Jogos.Update(JogoProcurado);
                ctx.SaveChanges();
            }
        }
    }
}
