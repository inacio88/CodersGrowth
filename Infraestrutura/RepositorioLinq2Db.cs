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
 
    public class RepositorioLinq2Db : IRepositorioPessoa
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["invent018.bancoDeDadosCG.dbo"].ConnectionString;

        public DataConnection Conectar()
        {
            DataConnection conexao = SqlServerTools.CreateDataConnection(connectionString);
            return conexao;
        }

        public void AtualizarPessoa(Pessoa pessoa)
        {
            using var bancoDados = Conectar();

            try
            {
                bancoDados.Update(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar pessoa", ex);
            }

        }

        public void CriarPessoa(Pessoa pessoa)
        {
            using var bancoDados = Conectar();
            try
            {
                bancoDados.Insert(pessoa);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar pessoa", ex);
            }
        }

        public bool ObterPessoaPorCpf(string Cpf, int Id)
        {
            using var bancoDados = Conectar();
            
            try
            {
                var pessoaBancoDados = bancoDados.GetTable<Pessoa>()
                .FirstOrDefault(p => p.Cpf == Cpf);

                if (pessoaBancoDados == null || pessoaBancoDados.Id == Id)
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter por cpf", ex);
            }

        }

        public Pessoa ObterPessoaPorId(int Id)
        {
            using var bancoDados = Conectar();

            try
            {
                var pessoa = bancoDados.GetTable<Pessoa>()
                .FirstOrDefault(p => p.Id == Id);
                return pessoa ?? throw new Exception("Obejto pesso nulo");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter por ID", ex);
            }

        }

        public List<Pessoa> ObterTodasPessoas()
        {
            using var bancoDados = Conectar();
            try
            {
                var query = from p in bancoDados.GetTable<Pessoa>()
                                orderby p.Nome ascending
                                select p;
                
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao obter todas as pessoas", ex);
            }

        }

        public void RemoverPessoa(int Id)
        {
            using var bancoDados = Conectar();
            
            try
            {
                bancoDados.GetTable<Pessoa>().Delete(p => p.Id == Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover pessoa", ex);
            }
        }
    }
}
    