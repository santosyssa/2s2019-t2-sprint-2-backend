using Senai.People.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.People.WebApi.Repositorys
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_People;User Id=sa;Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionairos = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
              string Query = "SELECT IdFuncionario, Nome,Sobrenome FROM Funcionarios";
         
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
        
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                            Nome = sdr["Nome"].ToString()
                           ,Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionairos.Add(funcionario);
                    }
                }

            }
           
            return funcionairos;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFuncionario, Nome,Sobrenome FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
         
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                   
                        while (sdr.Read())
                        {
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"]),
                                Nome = sdr["Nome"].ToString()
                               ,Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;

                }
            }

        }

        public void Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "Delete FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome,  Sobrenome = @Sobrenome Where IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                cmd.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarioDomain.IdFuncionario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
