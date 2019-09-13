using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }
        }

        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos cargo = ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
                return cargo;
            }
        }

        public void Cadastrar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Cargos cargo)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos CargoProcurado = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargo.IdCargo);
                CargoProcurado.Nome = cargo.Nome;
                ctx.Cargos.Update(CargoProcurado);
                ctx.SaveChanges();
            }
        }
    }
}
