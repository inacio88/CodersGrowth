using Dominio;
using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.DataProvider.SqlServer;
using System.Configuration;

namespace Infraestrutura
{
    public class Conexao
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["invent018.bancoDeDadosCG.dbo"].ConnectionString;

        public DataConnection Conectar()
        {
            DataConnection conexao = SqlServerTools.CreateDataConnection(connectionString);
            return conexao;
        }
    }

    public class RepositorioLinq2Db : IRepositorioPessoa
    {
        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();

            bancoDados.Update(pessoa);

            return pessoa;
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();

            bancoDados.Insert(pessoa);
        }

        public Pessoa ObterPessoaPorCpf(string Cpf)
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();

            var pessoa = bancoDados.GetTable<Pessoa>()
            .FirstOrDefault(p => p.Cpf == Cpf);

            if (pessoa == null)
                return new Pessoa();

            return pessoa;
        }

        public Pessoa ObterPessoaPorId(int Id)
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();

            var pessoa = bancoDados.GetTable<Pessoa>()
            .FirstOrDefault(p => p.Id == Id);

            return pessoa;
        }

        public List<Pessoa> ObterTodasPessoas()
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();

            var query = from p in bancoDados.GetTable<Pessoa>()
                        orderby p.Nome ascending
                        select p;

            return query.ToList();
        }

        public void RemoverPessoa(int Id)
        {
            var conexao = new Conexao();
            var bancoDados = conexao.Conectar();
            bancoDados.GetTable<Pessoa>().Delete(p => p.Id == Id);
        }
    }
}
    