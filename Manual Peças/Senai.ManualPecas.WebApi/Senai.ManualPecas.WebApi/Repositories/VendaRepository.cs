using Senai.ManualPecas.WebApi.Domains;
using Senai.ManualPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ManualPecas.WebApi.Repositories
{
    public class VendaRepository
    {
        ManualPecasContext ctx = new ManualPecasContext();

        string StringConexao = "Data Source=.\\SqlExpress; Initial Catalog=T_ManualPecas;User Id=sa;Pwd=132";

        string Query = "INSERT INTO Vendas (IdPeca, IdFornecedor, Preco) VALUES (@IdPeca, @IdFornecedor, @Preco)";
        

        public void Cadastrar(VendaViewModel venda)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query,con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdPeca", venda.IdPeca);
                    cmd.Parameters.AddWithValue("@IdFornecedor", venda.IdFornecedor);
                    cmd.Parameters.AddWithValue("@Preco", venda.Preco);

                    cmd.ExecuteNonQuery();

                }
            }
        }
    }
}
