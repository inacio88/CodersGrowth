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

            SqlCommand comando = new SqlCommand("SELECT * FROM pessoas", sqlConexao);
            //SqlDataReader dataReader = comando.ExecuteReader();

            sqlConexao.Close();

            return listaDePessoas;
        }

        public void CriarPessoa(Pessoa pessoa)
        {
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
