﻿using System;
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
        private static string connectionString = "Data Source=INVENT018;Initial Catalog=bancoDeDadosCG;User ID=sa;Password=sap@123";
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
            
                string incluiSQL = @"INSERT INTO pessoa (Nome, Email, DataNascimento, CPF) VALUES ("+
                "'"+pessoa.Nome + "','" +
                pessoa.Email + "','" +
                pessoa.DataNascimento + "','" +
                pessoa.Cpf + 
                "')";
            
                SqlCommand comando = new SqlCommand(incluiSQL, sqlConexao);
            
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
                string atualizaSQL = "UPDATE pessoa SET "+
                    "Nome='"+pessoa.Nome+"',"+
                    "Email='" + pessoa.Email + "'," +
                    "DataNascimento='" + pessoa.DataNascimento+ "'," +
                    "CPF='" + pessoa.Cpf + "'" +
                    "WHERE Id=" + Id;
                SqlCommand comando = new SqlCommand(atualizaSQL, sqlConexao);
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

            pessoa = ObterPessoaPorId(Id);
            return pessoa;
        }
    }
}
