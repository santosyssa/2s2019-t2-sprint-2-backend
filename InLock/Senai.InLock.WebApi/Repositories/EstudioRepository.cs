using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class EstudioRepository
    {
        public List<Estudios> Listar()
        {
            using (InlockContext context = new InlockContext())
            {
                return context.Estudios.Include(x => x.IdUsuarioNavigation).ToList();
            }
        }

        public Estudios BuscarPorId (int id)
        {
           using (InlockContext ctx = new InlockContext())
            {
                Estudios estudio = ctx.Estudios.FirstOrDefault(x => x.IdEstudio == id);
                return estudio;
            }
        }

        public void Cadastrar (Estudios estudios)
        {
            using (InlockContext ctx = new InlockContext())
            {
                ctx.Estudios.Add(estudios);
                ctx.SaveChanges();
            }
        }

        public void Atualizar (Estudios estudio)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Estudios EstudioEncontrado = ctx.Estudios.FirstOrDefault(x => x.IdEstudio == estudio.IdEstudio);
                EstudioEncontrado.NomeEstudio = estudio.NomeEstudio;
                ctx.Estudios.Update(EstudioEncontrado);
                ctx.SaveChanges();
            }
        }

        public void Deletar (int id)
        {
            using (InlockContext ctx = new InlockContext())
            {
                Estudios estudio = ctx.Estudios.Find(id);
                ctx.Estudios.Remove(estudio);
                ctx.SaveChanges();
            }
        }
    }
}
