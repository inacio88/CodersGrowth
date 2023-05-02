using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace GerenciamentoClientes
{
    internal class RepositorioSqlPessoa : IRepositorioPessoa
    {
        protected List<Pessoa> listaDePessoas = ListaPessoasSingleTon.obterInstancia();
        private static string connectionString = "Data Source=INVENT018;Initial Catalog=bancoDeDadosCG;User ID=sa;Password=sap@123";
        SqlConnection sqlConexao = new SqlConnection(connectionString);


        public List<Pessoa> ObterTodasPessoas()
        {
            sqlConexao.Open();

            SqlCommand comando = new SqlCommand("SELECT * FROM pessoa", sqlConexao);
            SqlDataReader dataReader = comando.ExecuteReader();

            sqlConexao.Close();

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
            //incluiSQL = "INSERT INTO pessoa (Nome, Email, DataNascimento, CPF) VALUES ('inacio','inaio@email.com','02/02/2000 00:00:00','222.222.222-22')";
            SqlCommand comando = new SqlCommand(incluiSQL, sqlConexao);
            comando.ExecuteNonQuery();

            sqlConexao.Close();
            
            listaDePessoas.Add(pessoa);
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
