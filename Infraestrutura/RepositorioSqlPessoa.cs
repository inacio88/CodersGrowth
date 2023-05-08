using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;
using Dominio;

namespace Infraestrutura
{
    public class RepositorioSqlPessoa : IRepositorioPessoa
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["invent018.bancoDeDadosCG.dbo"].ConnectionString;
        SqlConnection sqlConexao = new SqlConnection(connectionString);
        protected List<Pessoa> listaDePessoas = new List<Pessoa>();

        public List<Pessoa> ObterTodasPessoas()
        {
            if (listaDePessoas.Count() != decimal.Zero)
            {
                listaDePessoas = new List<Pessoa>();
            }

            try
            {
                sqlConexao.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM pessoa", sqlConexao);
                comando.CommandType = CommandType.Text;
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    listaDePessoas.Add(new Pessoa()
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Nome = dataReader["Nome"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        DataNascimento = Convert.ToDateTime(dataReader["DataNascimento"].ToString()),
                        Cpf = dataReader["CPF"].ToString(),
                    });
                }
                dataReader.Close();
                return listaDePessoas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConexao.Close();
            }

            return listaDePessoas;
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            try{ 
                sqlConexao.Open();

                string incluiSQL = @"INSERT INTO pessoa (Nome, Email, DataNascimento, CPF) VALUES (@Nome, @Email, @DataNascimento, @CPF)";
                SqlCommand comando = new SqlCommand(incluiSQL, sqlConexao);
                comando.Parameters.AddWithValue("@Nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@Email", pessoa.Email);
                comando.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConexao.Close();
            }

        }
        public void RemoverPessoa(int Id)
        {
            try
            {
                sqlConexao.Open();
                string deletarSQL = "DELETE FROM pessoa WHERE Id=" + Id;
                SqlCommand comando = new SqlCommand(deletarSQL, sqlConexao);
                comando.CommandType = CommandType.Text;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConexao.Close();
            }
        }
        public Pessoa ObterPessoaPorId(int Id)
        {
            var pessoaBuscada = new Pessoa();
            try
            {
                sqlConexao.Open();
                string pesquisaSQL = "SELECT * FROM pessoa WHERE Id="+Id;
                SqlCommand comando = new SqlCommand(pesquisaSQL, sqlConexao);
                comando.CommandType = CommandType.Text;
                SqlDataReader dataReader = comando.ExecuteReader();
                while (dataReader.Read())
                {
                    pessoaBuscada = new Pessoa()
                    {
                        Id = Convert.ToInt32(dataReader["Id"]),
                        Nome = dataReader["Nome"].ToString(),
                        Email = dataReader["Email"].ToString(),
                        DataNascimento = Convert.ToDateTime(dataReader["DataNascimento"].ToString()),
                        Cpf = dataReader["CPF"].ToString(),
                    };
                }
                dataReader.Close();
        
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConexao.Close();
            }
            return pessoaBuscada;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            var Id = pessoa.Id;
            
            try
            {
                sqlConexao.Open();
                string atualizaSQL = "UPDATE pessoa SET Nome=@Nome, Email=@Email, DataNascimento=@DataNascimento, CPF=@CPF WHERE Id=@Id";
                SqlCommand comando = new SqlCommand(atualizaSQL, sqlConexao);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@Nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@Email", pessoa.Email);
                comando.Parameters.AddWithValue("@DataNascimento", pessoa.DataNascimento);
                comando.Parameters.AddWithValue("@CPF", pessoa.Cpf);
                comando.Parameters.AddWithValue("@Id", pessoa.Id);

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConexao.Close();
            }

            pessoa = ObterPessoaPorId(Id);
            return pessoa;
        }
    }
}
