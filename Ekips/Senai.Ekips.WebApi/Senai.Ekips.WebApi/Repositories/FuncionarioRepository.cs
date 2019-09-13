using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.Include(x => x.IdDepartamentoNavigation).Include(y=> y.IdCargoNavigation).ToList();

            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionario = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
                return funcionario;
            }
        }

        public void Cadastrar(Funcionarios funcionario)
        {
            using(EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios FuncionarioEncontrado = ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == funcionario.IdFuncionario);
                FuncionarioEncontrado.Nome = funcionario.Nome;
                ctx.Funcionarios.Update(FuncionarioEncontrado);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionario = ctx.Funcionarios.Find(id);
                ctx.Funcionarios.Remove(funcionario);
                ctx.SaveChanges();
            }
        }
    }
}
