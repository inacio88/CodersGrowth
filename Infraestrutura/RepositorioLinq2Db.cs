using Dominio;
using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB.DataProvider.SqlServer;

namespace Infraestrutura
{
    public class Conexao
    {
        public DataConnection Conectar()
        {
            DataConnection conexao = SqlServerTools.CreateDataConnection("server=INVENT018;database=bancoDeDadosCG;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=sap@123");
            return conexao;
        }
    }

    public class RepositorioLinq2Db : IRepositorioPessoa
    {

        public Pessoa AtualizarPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public void CriarPessoa(Pessoa pessoa)
        {
            throw new NotImplementedException();
        }

        public Pessoa ObterPessoaPorCpf(string Cpf)
        {
            throw new NotImplementedException();
        }

        public Pessoa ObterPessoaPorId(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> ObterTodasPessoas()
        {
            var conexao = new Conexao();
            var db = conexao.Conectar();

            var query = from p in db.GetTable<Pessoa>()
                        orderby p.Nome ascending
                        select p;

            return query.ToList();
        }

        public void RemoverPessoa(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
