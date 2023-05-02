using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace GerenciamentoClientes
{
    internal class RepositorioSqlPessoa : IRepositorioPessoa
    {
        protected List<Pessoa> listaDePessoas = ListaPessoasSingleTon.obterInstancia();
        private static string connectionString = "Data Source=INVENT018;Initial Catalog=bancoDeDadosCG;User ID=sa;Password=sap@123";
        SqlConnection sqlConexao = new SqlConnection(connectionString);


        public List<Pessoa> ObterTodasPessoas()
        {
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
            sqlConexao.Open();
            
            string incluiSQL = @"INSERT INTO pessoa (Nome, Email, DataNascimento, CPF) VALUES ("+
            "'"+pessoa.Nome + "','" +
            pessoa.Email + "','" +
            pessoa.DataNascimento + "','" +
            pessoa.Cpf + 
            "')";
            
            SqlCommand comando = new SqlCommand(incluiSQL, sqlConexao);
            
            comando.ExecuteNonQuery();

            sqlConexao.Close();

        }
        public void RemoverPessoa(int Id)
        {
            var pessoa = ObterPessoaPorId(Id);

            listaDePessoas.Remove(pessoa);
        }
        public Pessoa ObterPessoaPorId(int Id)
        {
            var pessoaBuscada = listaDePessoas.Find(x => x.Id == Id);

            return pessoaBuscada;
        }

        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            var pessoaBuscada = ObterPessoaPorId(pessoa.Id);

            pessoaBuscada = pessoa;

            return pessoaBuscada;
        }
    }
}
