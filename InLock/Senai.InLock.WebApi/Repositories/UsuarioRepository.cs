using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (InlockContext context = new InlockContext())
            {
                Usuarios usuario = context.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);

                if (login == null)
                {
                    return null;
                }
                return usuario;
            }
        }

        public List<Usuarios> Listar()
        {
            using (InlockContext ctx = new InlockContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
        
    }
}
